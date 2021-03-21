namespace Nop.Web.Areas.Admin.Models.Catalog
{
    public partial record ProductConfiguratorCalculationModel
    {
        public int ConfiguratorId { get; set; }

        public string Json { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Tax { get; set; }
        public string SubTotal { get; set; }
        public bool IsValid { get; set; }
    }
}