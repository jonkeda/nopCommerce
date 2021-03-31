using System.Threading.Tasks;

namespace Nop.Plugin.Misc.Kozijnen.Imports
{
    public interface IImporter
    {
        public Task Import(IImportDefinition definition);
    }
}