using System.Collections.Generic;
using Nop.Services.Catalog;

namespace Nop.Plugin.Misc.Kozijnen.Imports
{
    public interface IProductConfiguratorDefinition : IImportDefinition
    {
        IProductConfiguratorProvider GetConfigurator();

        ProductImport GetProduct();
        
        IEnumerable<PictureImport> GetPictures();
    }
}