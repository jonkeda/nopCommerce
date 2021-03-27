using System;
using System.Threading.Tasks;
using Nop.Core.Domain.Catalog;
using Nop.Services.Media;
using Nop.Services.Plugins;

namespace Nop.Services.Catalog
{
    public abstract class ProductConfiguratorBasePlugin : BasePlugin, IProductConfiguratorPlugin
    {
        private readonly IProductConfiguratorService _productConfiguratorService;
        private readonly IProductService _productService;
        private readonly IPictureService _pictureService;

        protected ProductConfiguratorBasePlugin(IProductConfiguratorService productConfiguratorService,
            IProductService productService,
            IPictureService pictureService)
        {
            _productConfiguratorService = productConfiguratorService;
            _productService = productService;
            _pictureService = pictureService;
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

        protected virtual async Task<int> CreatePicture(byte[] pictureBinary, string mimeType, string seoFilename,
            string altAttribute, string titleAttribute)
        {
            var picture = _pictureService.InsertPictureAsync(pictureBinary, mimeType, seoFilename,
                altAttribute, titleAttribute);
            return picture.Id;
        }

        protected virtual async Task CreateProduct()
        {
            await _productService.InsertProductAsync(new Product
                {
                    ProductType = ProductType.SimpleProduct,
                    Name = "",
                    ShortDescription = "",
                    FullDescription = "",

                    MetaDescription = "",
                    MetaKeywords = "",
                    MetaTitle = "",

                    IsConfiguratorEnabled = true,
                    ConfiguratorId = 0,
                    Configuration = "",
                    ConfigurationDescription = "",
                    ConfigurationPictureId = 0
                });
        }
    }
}