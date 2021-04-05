using System.Collections.Generic;
using System.Xml.Serialization;

namespace Nop.Plugin.Misc.Kozijnen.Imports.Vouwwanden.AluminiumVouwwanden
{
    [XmlRoot("Imports")]
    public class AluminiumVouwwandImports : IProductImports
    {
        [XmlElement("Products")]
        public AluminiumVouwwandImportCollection Products { get; set; } = new AluminiumVouwwandImportCollection();

        public IEnumerable<ProductImport> GetProducts()
        {
            return Products;
        }
    }
}