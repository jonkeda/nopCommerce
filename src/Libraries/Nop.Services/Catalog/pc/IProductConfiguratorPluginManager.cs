using System.Threading.Tasks;
using Nop.Services.Plugins;

namespace Nop.Services.Catalog
{
    /// <summary>
    /// Represents a product configurator manager
    /// </summary>
    public partial interface IProductConfiguratorPluginManager : IPluginManager<IProductConfiguratorPlugin>
    {
        public Task<IProductConfiguratorProvider> GetProductConfiguratorProvider(int productConfiguratorid);
    }
}