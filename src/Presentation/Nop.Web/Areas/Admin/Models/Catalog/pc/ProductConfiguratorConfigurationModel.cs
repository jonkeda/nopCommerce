using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a ProductConfigurator Configuration model
    /// </summary>
    public partial record ProductConfiguratorConfigurationModel : BaseNopModel
    {
        #region Ctor

        public ProductConfiguratorConfigurationModel()
        {
            AvailableConfigurators = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        public int CurrentConfiguratorId { get; set; }

        [NopResourceDisplayName("Configurator")]
        public int ConfiguratorId { get; set; }
        public IList<SelectListItem> AvailableConfigurators { get; set; }

        [NopResourceDisplayName("Price")]
        public ProductConfiguratorField<decimal> Price { get; set; } = new();

        [NopResourceDisplayName("Tax")]
        public ProductConfiguratorField<decimal> Tax { get; set; } = new();

        [NopResourceDisplayName("PriceIncludingTax")]
        public ProductConfiguratorField<decimal> PriceIncludingTax { get; set; } = new();

        public string ViewName { get; set; }

        public object DefaultModel { get; set; }

        public Type ModelType { get; set; }

        #endregion
    }
}