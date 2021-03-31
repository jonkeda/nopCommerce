using System.Collections.Generic;
using System.Xml.Serialization;

namespace Nop.Plugin.Misc.Kozijnen.Imports
{
    public interface IProductImports
    {
        IEnumerable<ProductImport> GetProducts();
    }

    public class ProductImports : IProductImports
    {
        [XmlElement("Product")]
        public ProductImportCollection Products { get; set; }

        public IEnumerable<ProductImport> GetProducts()
        {
            return Products;
        }
    }
}