using Nop.Services.Common;

namespace Nop.Services.Catalog
{
    /// <summary>
    /// product configurator plugin
    /// </summary>
    public partial interface IProductConfiguratorPlugin : IMiscPlugin
    {
        IProductConfiguratorProvider GetProductConfiguratorProvider(string name);
    }
}