using Nop.Services.Plugins;

namespace Nop.Services.Catalog
{
    public abstract class ProductConfiguratorBasePlugin : BasePlugin, IProductConfiguratorPlugin
    {

        protected ProductConfiguratorBasePlugin()
        {
        }

        public abstract IProductConfiguratorProvider GetProductConfiguratorProvider(string name);
    }
}