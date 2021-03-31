using System;

namespace Nop.Plugin.Misc.Kozijnen.Imports
{
    public interface IProductImportDefinition : IImportDefinition
    {
        public string ProductFileName { get; set; }

        Type GetProductImportType();
    }
}