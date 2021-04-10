using System;
using Nop.Plugin.Misc.Kozijnen.Models.AluminiumVouwwand;
using Nop.Plugin.Misc.Kozijnen.Services;
using Nop.Services.Catalog;

namespace Nop.Plugin.Misc.Kozijnen.Imports.Vouwwanden.AluminiumVouwwanden
{
    public class AluminiumVouwwandenImportDefinition : IProductImportDefinition, IProductConfiguratorDefinition
    {
        public string ProductFileName { get; set; } = "Products.xml";

        public Type GetProductImportType()
        {
            return typeof(AluminiumVouwwandImports);
        }

        public IProductConfiguratorProvider GetConfigurator()
        {
            return new AluminiumVouwwandProductConfigurator();
        }

        public ProductImport GetProduct()
        {
            return new AluminiumVouwwandImport
            {
                Name = "Vouwwand",
                Published = true,
                AantalDelen = AantalDelen.Delen2,
                BreedteKozijn = 1700,
                CategoryName = null,
                DisplayOrder = 0,
                HoogteKozijn = 2000,
                KleurBinnenkant = "RAL9010",
                KleurBuitenkant = "RAL9010"
            };
        }
    }
}
