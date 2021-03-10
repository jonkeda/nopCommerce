using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a ProductConfigurator search model
    /// </summary>
    public partial record ProductConfiguratorSearchModel : BaseSearchModel
    {
        #region Ctor

        public ProductConfiguratorSearchModel()
        {
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Catalog.ProductConfigurators.List.SearchProductConfiguratorName")]
        public string SearchProductConfiguratorName { get; set; }

        #endregion
    }
}