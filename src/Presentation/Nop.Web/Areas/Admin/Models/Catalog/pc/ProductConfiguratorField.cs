namespace Nop.Web.Areas.Admin.Models.Catalog
{
    public class ProductConfiguratorField<T> : IProductConfiguratorField
    {
        public T Value { get; set; }
        public bool IsVisible { get; set; } = true;
        public string Error { get; set; }

        public override string ToString()
        {
            return Value?.ToString();
        }
    }
}