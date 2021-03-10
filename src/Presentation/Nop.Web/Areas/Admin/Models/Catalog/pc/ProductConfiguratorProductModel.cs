using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a ProductConfigurator product model
    /// </summary>
    public partial record ProductConfiguratorProductModel : BaseNopEntityModel
    {
        #region Properties

        public int ProductConfiguratorId { get; set; }

        public int ProductId { get; set; }

        [NopResourceDisplayName("Admin.Catalog.ProductConfigurators.Products.Fields.Product")]
        public string ProductName { get; set; }

        #endregion
    }
}