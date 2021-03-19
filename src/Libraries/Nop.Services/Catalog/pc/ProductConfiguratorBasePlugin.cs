using System;
using System.Threading.Tasks;
using Nop.Core.Domain.Catalog;
using Nop.Services.Plugins;

namespace Nop.Services.Catalog
{
    public abstract class ProductConfiguratorBasePlugin : BasePlugin, IProductConfiguratorPlugin
    {
        private readonly IProductConfiguratorService _productConfiguratorService;

        protected ProductConfiguratorBasePlugin(IProductConfiguratorService productConfiguratorService)
        {
            _productConfiguratorService = productConfiguratorService;
        }

        public abstract IProductConfiguratorProvider GetProductConfiguratorProvider(string name);

        protected async Task InstallProductConfigurator(IProductConfiguratorProvider provider)
        {
            var type = provider.GetType();
            var model = _productConfiguratorService.GetByFullClassNameAsync(type.FullName);
            if (model == null)
            {
                var productConfigurator = new ProductConfigurator {Name = type.Name, FullClassName = type.FullName};
                await _productConfiguratorService.InsertProductConfiguratorAsync(productConfigurator);
            }
        }
    }
}