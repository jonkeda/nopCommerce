using System.Collections.Generic;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a ProductConfigurator model
    /// </summary>
    public partial record ProductConfiguratorModel : BaseNopEntityModel, 
        ILocalizedModel<ProductConfiguratorLocalizedModel>
    {
        #region Ctor

        public ProductConfiguratorModel()
        {
            Locales = new List<ProductConfiguratorLocalizedModel>();

            ProductConfiguratorProductSearchModel = new ProductConfiguratorProductSearchModel();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Catalog.ProductConfigurator.Fields.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.Catalog.ProductConfigurator.Fields.Description")]
        public string Description { get; set; }

        [NopResourceDisplayName("Admin.Catalog.ProductConfigurator.Fields.MetaKeywords")]
        public string MetaKeywords { get; set; }

        [NopResourceDisplayName("Admin.Catalog.ProductConfigurator.Fields.MetaDescription")]
        public string MetaDescription { get; set; }

        [NopResourceDisplayName("Admin.Catalog.ProductConfigurator.Fields.MetaTitle")]
        public string MetaTitle { get; set; }

        [NopResourceDisplayName("Admin.Catalog.ProductConfigurator.Fields.Deleted")]
        public bool Deleted { get; set; }
       
        public IList<ProductConfiguratorLocalizedModel> Locales { get; set; }

        public ProductConfiguratorProductSearchModel ProductConfiguratorProductSearchModel { get; set; }

        #endregion
    }
}