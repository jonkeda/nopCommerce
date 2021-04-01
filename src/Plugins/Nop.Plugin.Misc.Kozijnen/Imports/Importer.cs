using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Media;
using Nop.Plugin.Misc.Kozijnen.Extensions;
using Nop.Services.Catalog;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Seo;

namespace Nop.Plugin.Misc.Kozijnen.Imports
{
    public class Importer : IImporter
    {
        #region Fields

        private readonly IProductConfiguratorService _productConfiguratorService;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IPictureService _pictureService;
        private readonly IUrlRecordService _urlRecordService;
        private readonly ILocalizationService _localizationService;
        private readonly ILanguageService _languageService;

        #endregion

        #region Constructor

        public Importer(IProductConfiguratorService productConfiguratorService,
            ICategoryService categoryService,
            IProductService productService,
            IPictureService pictureService,
            IUrlRecordService urlRecordService,
            ILocalizationService localizationService,
            ILanguageService languageService)
        {
            _productConfiguratorService = productConfiguratorService;
            _categoryService = categoryService;
            _productService = productService;
            _pictureService = pictureService;
            _urlRecordService = urlRecordService;
            _localizationService = localizationService;
            _languageService = languageService;
        }

        #endregion

        #region Import

        public async Task Import(IImportDefinition definition)
        {
            int configuratorId = 0;
            IProductConfiguratorProvider configurator = null;
            if (definition is IProductConfiguratorDefinition configuratorDefinition)
            {
                configurator = configuratorDefinition.GetConfigurator();
                configuratorId = await InstallProductConfigurator(configurator);
            }
            if (definition is ICategoryImportDefinition category)
            {
                await ImportCategory(category);
            }
            if (definition is IProductImportDefinition product)
            {
                await ImportProduct(product, configuratorId, configurator);
            }
            if (definition is ILanguageImportDefinition language)
            {
                await ImportLanguage(language);
            }

        }

        #endregion

        #region Language

        private async Task ImportLanguage(ILanguageImportDefinition definition)
        {
            foreach (var import in definition.LanguageFileNames)
            {
                var language = (await _languageService.GetAllLanguagesAsync()).FirstOrDefault(l => l.Name == import.Name);
                if (language != null)
                {
                    await using var s = definition.GetType().GetStream(import.FileName);
                    using var sr = new StreamReader(s);
                    await _localizationService.ImportResourcesFromXmlAsync(language, sr);
                }
            }
        }

        #endregion

        #region Category

        public async Task ImportCategory(ICategoryImportDefinition definition)
        {
            var text = definition.GetType().ReadAsString(definition.CategoryFileName);
            var imports = text.LoadFromText<CategoryImports>();
            if (imports != null)
            {
                foreach (var import in imports.Categories)
                {
                    await AddUpdateCategory(definition, import.Name, import.ParentCategory, import.PictureName, import.Published, import.DisplayOrder,
                        import.ShowOnHomePage);
                }
            }
        }

        private async Task AddUpdateCategory(ICategoryImportDefinition definition, 
            string name,
            string parentCategoryName,
            string pictureName,
            bool published,
            int displayOrder,
            bool show)
        {
            var parentCategoryId = 0;

            if (!string.IsNullOrEmpty(parentCategoryName))
            {
                var parentCategory = (await _categoryService.GetAllCategoriesAsync(parentCategoryName, showHidden: true)).FirstOrDefault();
                if (parentCategory != null)
                {
                    parentCategoryId = parentCategory.Id;
                }
            }
            
            var category = (await _categoryService.GetAllCategoriesAsync(name, showHidden: true)).FirstOrDefault();

            var isNew = false;
            if (category == null)
            {
                isNew = true;
                category = new Category
                {
                    CreatedOnUtc = DateTime.UtcNow
                };
            }

            category.Name = name;
            category.ParentCategoryId = parentCategoryId;
            // category.PictureId = pictureId;
            category.CategoryTemplateId = 1;

            category.MetaKeywords = null;
            category.MetaDescription = null;
            category.MetaTitle = null;

            category.PageSize = 18;
            category.PageSizeOptions = "6, 3, 9, 18";
            category.AllowCustomersToSelectPageSize = false;

            category.ShowOnHomepage = show;
            category.IncludeInTopMenu = true;
            category.Published = published;
            category.DisplayOrder = displayOrder;

            category.PriceRangeFiltering = false;

            category.UpdatedOnUtc = DateTime.UtcNow;

            if (!string.IsNullOrEmpty(pictureName))
            {
                var bytes = definition.GetType().ReadAsBytes(pictureName);
                if (bytes != null)
                {
                    if (isNew || category.PictureId == 0)
                    {
                        var picture = await _pictureService.InsertPictureAsync(
                            bytes,
                            MimeTypes.ImagePng,
                            await _pictureService.GetPictureSeNameAsync(category.Name), mediaType: MediaType.Image,
                            name: $"Category_{category.Name}");
                        category.PictureId = picture.Id;
                    }
                    else
                    {
                        var picture = await _pictureService.UpdatePictureAsync(category.PictureId,
                            bytes,
                            MimeTypes.ImagePng,
                            await _pictureService.GetPictureSeNameAsync(category.Name), mediaType: MediaType.Image,
                            name: $"Category_{category.Name}");
                        category.PictureId = picture.Id;
                    }
                }
            }

            if (isNew)
            {
                await _categoryService.InsertCategoryAsync(category);
            }
            else
            {
                await _categoryService.UpdateCategoryAsync(category);
            }

            //search engine name
            var seName = await _urlRecordService.ValidateSeNameAsync(category, category.Name, category.Name, true);
            await _urlRecordService.SaveSlugAsync(category, seName, 0);

            //return category.Id;
        }


        #endregion

        #region Product

        private const int TaxCategoryHighId = 1;

        public async Task ImportProduct(IProductImportDefinition definition, int configuratorId, IProductConfiguratorProvider configurator)
        {
            var text = definition.GetType().ReadAsString(definition.ProductFileName);
            var imports = (IProductImports)text.LoadFromText(definition.GetProductImportType());
            if (imports != null)
            {
                foreach (var import in imports.GetProducts())
                {
                    object model = import.GetConfiguration();

                    await AddUpdateProduct(definition, import.Name, import.CategoryName, import.PictureName, import.Published, import.DisplayOrder,
                        configuratorId, configurator, model);
                }
            }
        }

        private async Task<int> AddUpdateProduct(IProductImportDefinition definition,
            string name,
            string categoryName,
            string pictureName,
            bool published,
            int displayOrder,
            int configuratorId,
            IProductConfiguratorProvider configurator,
            object configurationModel)
        {
            string configuration;
            decimal price;
            string description;
            bool isValid;

            (configuration, description, price, isValid) = configurator.CalculateToJson(JsonConvert.SerializeObject(configurationModel));
            if (!isValid)
            {
                return 0;
            }

            var product = await _productService.GetProductByNameAsync(name);

            var isNew = false;
            if (product == null)
            {
                isNew = true;
                product = new Product
                {
                    CreatedOnUtc = DateTime.UtcNow
                };
            }

            product.Name = name;
            product.ProductType = ProductType.SimpleProduct;
            product.VisibleIndividually = true;
            product.ShortDescription = null;
            product.FullDescription = null;

            product.MetaKeywords = null;
            product.MetaDescription = null;
            product.MetaTitle = null;

            product.ProductTemplateId = 1;
            product.AllowCustomerReviews = false;

            product.IsShipEnabled = true;
            product.TaxCategoryId = TaxCategoryHighId;

            product.IsConfiguratorEnabled = true;
            product.ConfiguratorId = configuratorId;
            product.Configuration = configuration;
            product.ConfigurationDescription = description;

            product.ShowOnHomepage = false;
            product.Published = published;
            product.DisplayOrder = displayOrder;

            product.UpdatedOnUtc = DateTime.UtcNow;

            if (isNew)
            {
                await _productService.InsertProductAsync(product);
            }
            else
            {
                await _productService.UpdateProductAsync(product);
            }

            //search engine name
            var seName = await _urlRecordService.ValidateSeNameAsync(product, product.Name, product.Name, true);
            await _urlRecordService.SaveSlugAsync(product, seName, 0);

            if (!string.IsNullOrEmpty(categoryName))
            {
                var existingProductCategories =
                    await _categoryService.GetProductCategoriesByProductIdAsync(product.Id, true);
                if (!existingProductCategories.Any())
                {
                    var categoryId = 0;

                    if (!string.IsNullOrEmpty(categoryName))
                    {
                        var category = (await _categoryService.GetAllCategoriesAsync(categoryName, showHidden: true))
                            .FirstOrDefault();
                        if (category != null)
                        {
                            categoryId = category.Id;
                        }
                    }

                    await _categoryService.InsertProductCategoryAsync(new ProductCategory
                    {
                        ProductId = product.Id, CategoryId = categoryId, DisplayOrder = 1
                    });
                }
            }
            if (!string.IsNullOrEmpty(pictureName)
                && !(await _productService.GetProductPicturesByProductIdAsync(product.Id)).Any())
            {
                var picture = await _pictureService.InsertPictureAsync(
                    definition.GetType().ReadAsBytes(pictureName),
                    MimeTypes.ImagePng,
                    await _pictureService.GetPictureSeNameAsync(product.Name), mediaType: MediaType.Image,
                    name: $"Product_{product.Name}");
                await _productService.InsertProductPictureAsync(new ProductPicture
                {
                    PictureId = picture.Id,
                    ProductId = product.Id,
                    DisplayOrder = 0
                });
            }

            return product.Id;
        }

        #endregion

        #region ProductConfigurator

        protected async Task<int> InstallProductConfigurator(IProductConfiguratorProvider provider)
        {
            var type = provider.GetType();
            var model = _productConfiguratorService.GetByFullClassNameAsync(type.FullName);
            ProductConfigurator productConfigurator = null;
            if (model == null)
            {
                productConfigurator = new ProductConfigurator { Name = type.Name, FullClassName = type.FullName };
                await _productConfiguratorService.InsertProductConfiguratorAsync(productConfigurator);
                return productConfigurator.Id;
            }
            productConfigurator =
                (await _productConfiguratorService.GetAllProductConfiguratorsAsync(type.Name)).FirstOrDefault();
            if (productConfigurator != null)
            {
                return productConfigurator.Id;
            }
            return 0;
        }

        #endregion
    }
}
