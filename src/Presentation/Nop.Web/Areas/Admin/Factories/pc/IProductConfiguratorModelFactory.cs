using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core.Domain.Catalog;
using Nop.Web.Areas.Admin.Models.Catalog;

namespace Nop.Web.Areas.Admin.Factories
{
    /// <summary>
    /// Represents the ProductConfigurator model factory
    /// PCFG
    /// </summary>
    public partial interface IProductConfiguratorModelFactory
    {
        /// <summary>
        /// Prepare ProductConfigurator search model
        /// </summary>
        /// <param name="searchModel">ProductConfigurator search model</param>
        /// <returns>ProductConfigurator search model</returns>
        Task<ProductConfiguratorSearchModel> PrepareProductConfiguratorSearchModelAsync(ProductConfiguratorSearchModel searchModel);

        /// <summary>
        /// Prepare ProductConfigurator Configuration
        /// </summary>
        /// <param name="configurationModel">ProductConfigurator configuration model</param>
        /// <returns>ProductConfigurator configuration model</returns>
        Task<ProductConfiguratorConfigurationModel> PrepareProductConfiguratorConfigurationModelAsync(ProductConfiguratorConfigurationModel configurationModel);

        /// <summary>
        /// Prepare paged ProductConfigurator list model
        /// </summary>
        /// <param name="searchModel">ProductConfigurator search model</param>
        /// <returns>ProductConfigurator list model</returns>
        Task<ProductConfiguratorListModel> PrepareProductConfiguratorListModelAsync(ProductConfiguratorSearchModel searchModel);

        /// <summary>
        /// Prepare ProductConfigurator model
        /// </summary>
        /// <param name="model">ProductConfigurator model</param>
        /// <param name="productConfigurator">ProductConfigurator</param>
        /// <param name="excludeProperties">Whether to exclude populating of some properties of model</param>
        /// <returns>ProductConfigurator model</returns>
        Task<ProductConfiguratorModel> PrepareProductConfiguratorModelAsync(ProductConfiguratorModel model,
            ProductConfigurator productConfigurator, bool excludeProperties = false);

        /// <summary>
        /// Prepare ProductConfigurator select items
        /// </summary>
        /// <param name="items"></param>
        /// <param name="withSpecialDefaultItem"></param>
        /// <param name="defaultItemText"></param>
        /// <returns></returns>
        Task PrepareProductConfiguratorsAsync(IList<SelectListItem> items, bool withSpecialDefaultItem = true, string defaultItemText = null);

        /// <summary>
        /// Prepare paged ProductConfigurator product list model
        /// </summary>
        /// <param name="searchModel">ProductConfigurator product search model</param>
        /// <param name="productConfigurator">ProductConfigurator</param>
        /// <returns>ProductConfigurator product list model</returns>
        //Task<ProductConfiguratorProductListModel> PrepareProductConfiguratorProductListModelAsync(ProductConfiguratorProductSearchModel searchModel,
        //   ProductConfigurator productConfigurator);

        /// <summary>
        /// Prepare product search model to add to the ProductConfigurator
        /// </summary>
        /// <param name="searchModel">Product search model to add to the ProductConfigurator</param>
        /// <returns>Product search model to add to the ProductConfigurator</returns>
        //Task<AddProductToProductConfiguratorSearchModel> PrepareAddProductToProductConfiguratorSearchModelAsync(AddProductToProductConfiguratorSearchModel searchModel);

        /// <summary>
        /// Prepare paged product list model to add to the ProductConfigurator
        /// </summary>
        /// <param name="searchModel">Product search model to add to the ProductConfigurator</param>
        /// <returns>Product list model to add to the ProductConfigurator</returns>
        //Task<AddProductToProductConfiguratorListModel> PrepareAddProductToProductConfiguratorListModelAsync(AddProductToProductConfiguratorSearchModel searchModel);
    }
}