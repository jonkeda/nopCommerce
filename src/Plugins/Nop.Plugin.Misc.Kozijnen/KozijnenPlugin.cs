using System.Threading.Tasks;
using Nop.Plugin.Misc.Kozijnen.Services;
using Nop.Services.Catalog;

namespace Nop.Plugin.Misc.Kozijnen
{
    /// <summary>
    /// Rename this file and change to the correct type
    /// </summary>
    public class KozijnenPlugin : ProductConfiguratorBasePlugin
    {
        public KozijnenPlugin(IProductConfiguratorService service) : base(service)
        {
            
        }

        #region Methods

        /// <summary>
        /// Install the plugin
        /// </summary>
        public override async Task InstallAsync()
        {
            await InstallProductConfigurator(new AluminiumVouwwandProductConfigurator());

            await base.InstallAsync();
        }

        /// <summary>
        /// Uninstall the plugin
        /// </summary>
        public override async Task UninstallAsync()
        {

            await base.UninstallAsync();
        }

        public override IProductConfiguratorProvider GetProductConfiguratorProvider(string name)
        {
            if (name == typeof(AluminiumVouwwandProductConfigurator).FullName)
            {
                return new AluminiumVouwwandProductConfigurator();
            }
            return null;
        }

        #endregion
    }
}
