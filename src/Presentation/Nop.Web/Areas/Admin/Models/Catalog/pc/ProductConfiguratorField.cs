namespace Nop.Web.Areas.Admin.Models.Catalog
{
    public class ProductConfiguratorField<T> : IProductConfiguratorField
    {
        public ProductConfiguratorField()
        {
        }

        public ProductConfiguratorField(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public bool IsVisible { get; set; } = true;
        public string Error { get; set; }

        public override string ToString()
        {
            return Value?.ToString();
        }

        public static implicit operator ProductConfiguratorField<T>(T value)
        {
            return new(value);
        }

        public static explicit operator T(ProductConfiguratorField<T> value)
        {
            return value.Value;
        }
    }
}