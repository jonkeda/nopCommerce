using System;
using System.Linq;
using System.Threading.Tasks;
using Nop.Core.Domain.Catalog;
using Nop.Plugin.Misc.Kozijnen.Models.AluminiumVouwwand;
using Nop.Plugin.Misc.Kozijnen.Services;
using Nop.Services.Catalog;
using Nop.Services.Media;
using Nop.Services.Seo;

namespace Nop.Plugin.Misc.Kozijnen
{
    /// <summary>
    /// Rename this file and change to the correct type
    /// </summary>
    public class KozijnenInstaller : IKozijnenInstaller
    {
        #region Fields

        private readonly IProductConfiguratorService _productConfiguratorService;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IPictureService _pictureService;
        private readonly IUrlRecordService _urlRecordService;

        #endregion

        #region Constructor

        public KozijnenInstaller(IProductConfiguratorService productConfiguratorService,
            ICategoryService categoryService,
            IProductService productService,
            IPictureService pictureService,
            IUrlRecordService urlRecordService)
        {
            _productConfiguratorService = productConfiguratorService;
            _categoryService = categoryService;
            _productService = productService;
            _pictureService = pictureService;
            _urlRecordService = urlRecordService;
        }

        #endregion

        #region Catalogs

        public async Task InstallData()
        {
            await AddUpdateCategoriesVouwwanden();

            await AddUpdateCategoriesKozijnen();

            await AddUpdateCategoriesSchuifpuien();

            await AddUpdateCategoriesDeuren();
        }

        private async Task AddUpdateCategoriesVouwwanden()
        {
            var configurator = new AluminiumVouwwandProductConfigurator();

            var configuratorId = await InstallProductConfigurator(configurator);

            int id = await AddUpdateCategory("Vouwwanden", 0, 0, true, 40, true);

            int kunstofid = await AddUpdateCategory("Kunstof vouwwanden", id, 0, true, 10, false);

            int aluminiumid = await AddUpdateCategory("Aluminium vouwwanden", id, 0, true, 20, false);

            var model = configurator.GetDefault();
            model.AantalDelen = AantalDelen.Delen2;
            await AddUpdateProduct("2 delige aluminium vouwwand", aluminiumid, 0, true, 10, configuratorId,
                configurator, model);

            model = configurator.GetDefault();
            model.AantalDelen = AantalDelen.Delen3;
            await AddUpdateProduct("3 delige aluminium vouwwand", aluminiumid, 0, true, 10, configuratorId,
                configurator, model);

            model = configurator.GetDefault();
            model.AantalDelen = AantalDelen.Delen4;
            await AddUpdateProduct("4 delige aluminium vouwwand", aluminiumid, 0, true, 10, configuratorId,
                configurator, model);

            model = configurator.GetDefault();
            model.AantalDelen = AantalDelen.Delen5;
            await AddUpdateProduct("5 delige aluminium vouwwand", aluminiumid, 0, true, 10, configuratorId,
                configurator, model);

            model = configurator.GetDefault();
            model.AantalDelen = AantalDelen.Delen6;
            await AddUpdateProduct("6 delige aluminium vouwwand", aluminiumid, 0, true, 10, configuratorId,
                configurator, model);
        }

        private async Task AddUpdateCategoriesDeuren()
        {
            int id = await AddUpdateCategory("Deuren", 0, 0, true, 20, true);

            int kunstofid = await AddUpdateCategory("Kunstof deuren", id, 0, true, 10, false);

            int aluminiumid = await AddUpdateCategory("Aluminium deuren", id, 0, true, 20, false);
        }


        private async Task AddUpdateCategoriesSchuifpuien()
        {
            int id = await AddUpdateCategory("Schuifpuien", 0, 0, true, 30, true);

            int kunstofid = await AddUpdateCategory("Kunstof schuifpuien", id, 0, true, 10, false);

            int aluminiumid = await AddUpdateCategory("Aluminium schuifpuien", id, 0, true, 20, false);
        }

        private async Task AddUpdateCategoriesKozijnen()
        {
            int id = await AddUpdateCategory("Kozijnen", 0, 0, true, 10, true);

            int kunstofid = await AddUpdateCategory("Kunstof kozijnen", id, 0, true, 10, false);

            int aluminiumid = await AddUpdateCategory("Aluminium kozijnen", id, 0, true, 20, false);
        }

        private async Task<int> AddUpdateCategory(string name,
            int parentCategoryId,
            int pictureId,
            bool published,
            int displayOrder,
            bool show)
        {
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
            category.PictureId = pictureId;
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

            return category.Id;
        }

        #endregion

        #region Products

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

        private async Task<int> AddUpdateProduct<T>(string name,
            int categoryId,
            int pictureId,
            bool published,
            int displayOrder,
            int configuratorId,
            ProductConfiguratorBase<T> configurator,
            T model)
        {
            string configuration;
            decimal price;
            string description;
            bool isValid;
            (configuration, description, price, isValid) = configurator.CalculateToJson(model);
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

            return product.Id;
        }

        private const int TaxCategoryHighId = 1;

        #endregion
    }
}