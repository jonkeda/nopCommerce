namespace Nop.Web.Areas.Admin.Models.Catalog
{
    public partial record ProductConfiguratorCalculationModel
    {
        public int ConfiguratorId { get; set; }

        public string Json { get; set; }
    }
}