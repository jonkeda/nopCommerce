using System.Xml.Serialization;

namespace Nop.Plugin.Misc.Kozijnen.Imports
{
    [XmlRoot("Imports")]
    public class CategoryImports
    {
        [XmlElement("Category")]
        public CategoryImportCollection Categories { get; set; } = new CategoryImportCollection();
    }
}