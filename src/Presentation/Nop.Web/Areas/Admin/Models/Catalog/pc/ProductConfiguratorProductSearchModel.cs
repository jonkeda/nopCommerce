using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a ProductConfigurator product search model
    /// </summary>
    public partial record ProductConfiguratorProductSearchModel : BaseSearchModel
    {
        #region Properties

        public int ProductConfiguratorId { get; set; }

        #endregion
    }
}