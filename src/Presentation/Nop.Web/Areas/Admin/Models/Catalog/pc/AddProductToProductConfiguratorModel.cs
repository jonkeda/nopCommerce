using System.Collections.Generic;
using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a product model to add to the ProductConfigurator
    /// </summary>
    public partial record AddProductToProductConfiguratorModel : BaseNopModel
    {
        #region Ctor

        public AddProductToProductConfiguratorModel()
        {
            SelectedProductIds = new List<int>();
        }
        #endregion

        #region Properties

        public int ProductConfiguratorId { get; set; }

        public IList<int> SelectedProductIds { get; set; }

        #endregion
    }
}