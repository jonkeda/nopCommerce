using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nop.Services.Customers;
using Nop.Services.Plugins;

namespace Nop.Services.Catalog
{
    public class ProductConfiguratorPluginManager : PluginManager<IProductConfiguratorPlugin>, IProductConfiguratorPluginManager
    {
        private readonly IProductConfiguratorService _productConfiguratorService;

        public ProductConfiguratorPluginManager(ICustomerService customerService, 
            IPluginService pluginService, 
            IProductConfiguratorService productConfiguratorService) 
            : base(customerService, pluginService)
        {
            _productConfiguratorService = productConfiguratorService;
        }

        public async Task<IProductConfiguratorProvider> GetProductConfiguratorProvider(int productConfiguratorid)
        {
            var productConfigurator = await _productConfiguratorService.GetProductConfiguratorByIdAsync(productConfiguratorid);
            if (productConfigurator == null)
            {
                return null;
            }
            var plugins = await LoadAllPluginsAsync();
            return GetProductConfigurator(plugins, productConfigurator.FullClassName);
        }

        private IProductConfiguratorProvider GetProductConfigurator(IEnumerable<IProductConfiguratorPlugin> plugins, string name)
        {
            return plugins.Select(plugin => plugin.GetProductConfiguratorProvider(name))
                .FirstOrDefault(productConfigurator => productConfigurator != null);
        }
    }
}
