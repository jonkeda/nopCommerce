namespace Nop.Services.Catalog
{
    public class ProductConfiguratorParsed
    {
        public ProductConfiguratorParsed(int configuratorId, 
            string configuration, 
            object configuratorModel, 
            string description, 
            decimal price, 
            bool isValid)
        {
            ConfiguratorId = configuratorId;
            Configuration = configuration;
            ConfiguratorModel = configuratorModel;
            Description = description;
            Price = price;
            IsValid = isValid;
        }

        public bool IsValid { get; }

        public decimal Price { get; }

        public string Description { get; }

        public object ConfiguratorModel { get; }

        public string Configuration { get; }

        public int ConfiguratorId { get; }
    }
}