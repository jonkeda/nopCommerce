using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a ProductConfigurator product list model
    /// </summary>
    public partial record ProductConfiguratorProductListModel : BasePagedListModel<ProductConfiguratorProductModel>
    {
    }
}