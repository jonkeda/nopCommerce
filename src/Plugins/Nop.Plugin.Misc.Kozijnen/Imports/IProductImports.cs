using System.Collections.Generic;

namespace Nop.Plugin.Misc.Kozijnen.Imports
{
    public interface IProductImports
    {
        IEnumerable<ProductImport> GetProducts();
    }
}