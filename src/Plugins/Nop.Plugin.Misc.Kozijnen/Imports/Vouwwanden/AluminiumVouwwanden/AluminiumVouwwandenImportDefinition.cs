using System;
using Nop.Plugin.Misc.Kozijnen.Services;
using Nop.Services.Catalog;

namespace Nop.Plugin.Misc.Kozijnen.Imports.Vouwwanden.AluminiumVouwwanden
{
    public class AluminiumVouwwandenImportDefinition : ICategoryImportDefinition, IProductImportDefinition, IProductConfiguratorDefinition
    {
        public string CategoryFileName { get; set; } = "Categories.xml";

        public string ProductFileName { get; set; } = "Products.xml";
        public Type GetProductImportType()
        {
            return typeof(AluminiumVouwwandImports);
        }

        public IProductConfiguratorProvider GetConfigurator()
        {
            return new AluminiumVouwwandProductConfigurator();
        }
    }
}
