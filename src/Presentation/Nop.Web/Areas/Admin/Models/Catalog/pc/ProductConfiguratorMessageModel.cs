using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Catalog
{
    public partial record ProductConfiguratorMessageModel
    {
        [NopResourceDisplayName("Admin.Catalog.ProductConfigurators.Fields.Message")]
        public string Message { get; set; }
    }
}