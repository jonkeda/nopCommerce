using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nop.Core.Domain.Catalog;
using Nop.Services.Catalog;
using Nop.Services.Localization;
using Nop.Services.Seo;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Catalog;
using Nop.Web.Framework.Factories;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Web.Areas.Admin.Factories
{
    /// <summary>
    /// Represents the ProductConfigurator model factory implementation
    /// </summary>
    public partial class ProductConfiguratorModelFactory : IProductConfiguratorModelFactory
    {
        #region Fields

        private readonly IBaseAdminModelFactory _baseAdminModelFactory;
        private readonly IProductConfiguratorService _productConfiguratorService;
        private readonly ILocalizationService _localizationService;
        private readonly ILocalizedModelFactory _localizedModelFactory;
        private readonly IProductService _productService;
        private readonly IUrlRecordService _urlRecordService;

        #endregion

        #region Ctor

        public ProductConfiguratorModelFactory(
            IBaseAdminModelFactory baseAdminModelFactory,
            IProductConfiguratorService productConfiguratorService,
            ILocalizationService localizationService,
            ILocalizedModelFactory localizedModelFactory,
            IProductService productService,
            IUrlRecordService urlRecordService)
        {
            _baseAdminModelFactory = baseAdminModelFactory;
            _productConfiguratorService = productConfiguratorService;
            _localizationService = localizationService;
            _localizedModelFactory = localizedModelFactory;
            _productService = productService;
            _urlRecordService = urlRecordService;
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Prepare ProductConfigurator product search model
        /// </summary>
        /// <param name="searchModel">ProductConfigurator product search model</param>
        /// <param name="productConfigurator">ProductConfigurator</param>
        /// <returns>ProductConfigurator product search model</returns>
        protected virtual ProductConfiguratorProductSearchModel PrepareProductConfiguratorProductSearchModel(ProductConfiguratorProductSearchModel searchModel,
            ProductConfigurator productConfigurator)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            if (productConfigurator == null)
                throw new ArgumentNullException(nameof(productConfigurator));

            searchModel.ProductConfiguratorId = productConfigurator.Id;

            //prepare page parameters
            searchModel.SetGridPageSize();

            return searchModel;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepare ProductConfigurator search model
        /// </summary>
        /// <param name="searchModel">ProductConfigurator search model</param>
        /// <returns>ProductConfigurator search model</returns>
        public virtual async Task<ProductConfiguratorSearchModel> PrepareProductConfiguratorSearchModelAsync(ProductConfiguratorSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare page parameters
            searchModel.SetGridPageSize();

            return searchModel;
        }

        /// <summary>
        /// Prepare paged ProductConfigurator list model
        /// </summary>
        /// <param name="searchModel">ProductConfigurator search model</param>
        /// <returns>ProductConfigurator list model</returns>
        public virtual async Task<ProductConfiguratorListModel> PrepareProductConfiguratorListModelAsync(ProductConfiguratorSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //get ProductConfigurators
            var ProductConfigurators = await _productConfiguratorService.GetAllProductConfiguratorsAsync(
                productConfiguratorName: searchModel.SearchProductConfiguratorName,
                pageIndex: searchModel.Page - 1, pageSize: searchModel.PageSize);

            //prepare grid model
            var model = await new ProductConfiguratorListModel().PrepareToGridAsync(searchModel, ProductConfigurators, () =>
            {
                //fill in model values from the entity
                return ProductConfigurators.SelectAwait(async ProductConfigurator =>
                {
                    var productConfiguratorModel = ProductConfigurator.ToModel<ProductConfiguratorModel>();

                    return productConfiguratorModel;
                });
            });

            return model;
        }

        /// <summary>
        /// Prepare ProductConfigurator model
        /// </summary>
        /// <param name="model">ProductConfigurator model</param>
        /// <param name="productConfigurator">ProductConfigurator</param>
        /// <param name="excludeProperties">Whether to exclude populating of some properties of model</param>
        /// <returns>ProductConfigurator model</returns>
        public virtual async Task<ProductConfiguratorModel> PrepareProductConfiguratorModelAsync(ProductConfiguratorModel model,
            ProductConfigurator productConfigurator, bool excludeProperties = false)
        {
            Action<ProductConfiguratorLocalizedModel, int> localizedModelConfiguration = null;

            if (productConfigurator != null)
            {
                //fill in model values from the entity
                if (model == null)
                {
                    model = productConfigurator.ToModel<ProductConfiguratorModel>();
                }

                //prepare nested search model
                PrepareProductConfiguratorProductSearchModel(model.ProductConfiguratorProductSearchModel, productConfigurator);

                //define localized model configuration action
                localizedModelConfiguration = async (locale, languageId) =>
                {
                    locale.Name = await _localizationService.GetLocalizedAsync(productConfigurator, entity => entity.Name, languageId, false, false);
                    locale.ShortDescription = await _localizationService.GetLocalizedAsync(productConfigurator, entity => entity.ShortDescription, languageId, false, false);
                    locale.FullDescription = await _localizationService.GetLocalizedAsync(productConfigurator, entity => entity.FullDescription, languageId, false, false);
                    locale.MetaKeywords = await _localizationService.GetLocalizedAsync(productConfigurator, entity => entity.MetaKeywords, languageId, false, false);
                    locale.MetaDescription = await _localizationService.GetLocalizedAsync(productConfigurator, entity => entity.MetaDescription, languageId, false, false);
                    locale.MetaTitle = await _localizationService.GetLocalizedAsync(productConfigurator, entity => entity.MetaTitle, languageId, false, false);
                };
            }

            //prepare localized models
            if (!excludeProperties)
                model.Locales = await _localizedModelFactory.PrepareLocalizedModelsAsync(localizedModelConfiguration);

            return model;
        }

        ///// <summary>
        ///// Prepare paged ProductConfigurator product list model
        ///// </summary>
        ///// <param name="searchModel">ProductConfigurator product search model</param>
        ///// <param name="productConfigurator">ProductConfigurator</param>
        ///// <returns>ProductConfigurator product list model</returns>
        //public virtual async Task<ProductConfiguratorProductListModel> PrepareProductConfiguratorProductListModelAsync(ProductConfiguratorProductSearchModel searchModel,
        //    ProductConfigurator productConfigurator)
        //{
        //    if (searchModel == null)
        //        throw new ArgumentNullException(nameof(searchModel));

        //    if (productConfigurator == null)
        //        throw new ArgumentNullException(nameof(productConfigurator));

        //    //get product ProductConfigurators
        //    var productProductConfigurators = await _productConfiguratorService.GetProductProductConfiguratorsByProductConfiguratorIdAsync(showHidden: true,
        //        productConfiguratorId: productConfigurator.Id,
        //        pageIndex: searchModel.Page - 1, pageSize: searchModel.PageSize);

        //    //prepare grid model
        //    var model = await new ProductConfiguratorProductListModel().PrepareToGridAsync(searchModel, productProductConfigurators, () =>
        //    {
        //        return productProductConfigurators.SelectAwait(async productProductConfigurator =>
        //        {
        //            //fill in model values from the entity
        //            var productConfiguratorProductModel = productProductConfigurator.ToModel<ProductConfiguratorProductModel>();

        //            //fill in additional values (not existing in the entity)
        //            productConfiguratorProductModel.ProductName = (await _productService.GetProductByIdAsync(productProductConfigurator.ProductId))?.Name;

        //            return productConfiguratorProductModel;
        //        });
        //    });

        //    return model;
        //}

        ///// <summary>
        ///// Prepare product search model to add to the ProductConfigurator
        ///// </summary>
        ///// <param name="searchModel">Product search model to add to the ProductConfigurator</param>
        ///// <returns>Product search model to add to the ProductConfigurator</returns>
        //public virtual async Task<AddProductToProductConfiguratorSearchModel> PrepareAddProductToProductConfiguratorSearchModelAsync(AddProductToProductConfiguratorSearchModel searchModel)
        //{
        //    if (searchModel == null)
        //        throw new ArgumentNullException(nameof(searchModel));

        //    //prepare available categories
        //    await _baseAdminModelFactory.PrepareCategoriesAsync(searchModel.AvailableCategories);

        //    //prepare available ProductConfigurators
        //    await _baseAdminModelFactory.PrepareProductConfiguratorsAsync(searchModel.AvailableProductConfigurators);

        //    //prepare available stores
        //    await _baseAdminModelFactory.PrepareStoresAsync(searchModel.AvailableStores);

        //    //prepare available vendors
        //    await _baseAdminModelFactory.PrepareVendorsAsync(searchModel.AvailableVendors);

        //    //prepare available product types
        //    await _baseAdminModelFactory.PrepareProductTypesAsync(searchModel.AvailableProductTypes);

        //    //prepare page parameters
        //    searchModel.SetPopupGridPageSize();

        //    return searchModel;
        //}

        ///// <summary>
        ///// Prepare paged product list model to add to the ProductConfigurator
        ///// </summary>
        ///// <param name="searchModel">Product search model to add to the ProductConfigurator</param>
        ///// <returns>Product list model to add to the ProductConfigurator</returns>
        //public virtual async Task<AddProductToProductConfiguratorListModel> PrepareAddProductToProductConfiguratorListModelAsync(AddProductToProductConfiguratorSearchModel searchModel)
        //{
        //    if (searchModel == null)
        //        throw new ArgumentNullException(nameof(searchModel));

        //    //get products
        //    var products = await _productService.SearchProductsAsync(showHidden: true,
        //        categoryIds: new List<int> { searchModel.SearchCategoryId },
        //        productConfiguratorIds: new List<int> { searchModel.SearchProductConfiguratorId },
        //        storeId: searchModel.SearchStoreId,
        //        vendorId: searchModel.SearchVendorId,
        //        productType: searchModel.SearchProductTypeId > 0 ? (ProductType?)searchModel.SearchProductTypeId : null,
        //        keywords: searchModel.SearchProductName,
        //        pageIndex: searchModel.Page - 1, pageSize: searchModel.PageSize);

        //    //prepare grid model
        //    var model = await new AddProductToProductConfiguratorListModel().PrepareToGridAsync(searchModel, products, () =>
        //    {
        //        return products.SelectAwait(async product =>
        //        {
        //            var productModel = product.ToModel<ProductModel>();

        //            productModel.SeName = await _urlRecordService.GetSeNameAsync(product, 0, true, false);

        //            return productModel;
        //        });
        //    });

        //    return model;
        //}

        #endregion
    }
}