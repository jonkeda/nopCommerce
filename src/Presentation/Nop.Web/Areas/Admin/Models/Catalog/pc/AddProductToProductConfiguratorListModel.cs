using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a product list model to add to the ProductConfigurator
    /// </summary>
    public partial record AddProductToProductConfiguratorListModel : BasePagedListModel<ProductModel>
    {
    }
}