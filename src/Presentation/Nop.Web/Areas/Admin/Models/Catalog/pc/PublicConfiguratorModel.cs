namespace Nop.Web.Areas.Admin.Models.Catalog
{
    public interface IProductConfiguratorField { }

    public class ProductConfiguratorField<T> : IProductConfiguratorField
    {
        public T Value { get; set; }
        //public T Default { get; set; }
        public bool IsVisible { get; set; } = true;
        public string Error { get; set; }

        public override string ToString()
        {
            return Value?.ToString();
        }
    }
    public class ProductConfiguratorBaseModel
    {
        public ProductConfiguratorField<int> Price { get; set; } = new();

        public ProductConfiguratorField<int> Tax { get; set; } = new();

    }
}