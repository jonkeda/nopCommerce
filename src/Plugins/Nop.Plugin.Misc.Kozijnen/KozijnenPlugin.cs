using System.Threading.Tasks;
using Nop.Core;
using Nop.Plugin.Misc.Kozijnen.Services;
using Nop.Services.Catalog;

namespace Nop.Plugin.Misc.Kozijnen
{
    /// <summary>
    /// Rename this file and change to the correct type
    /// </summary>
    public class KozijnenPlugin : ProductConfiguratorBasePlugin
    {
        private readonly IKozijnenInstaller _kozijnenInstaller;
        private readonly IWebHelper _webHelper;

        public KozijnenPlugin(IKozijnenInstaller kozijnenInstaller,
            IWebHelper webHelper)
        {
            _kozijnenInstaller = kozijnenInstaller;
            _webHelper = webHelper;
        }

        #region Methods

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/Kozijnen/Update";
        }

        /// <summary>
        /// Install the plugin
        /// </summary>
        public override async Task InstallAsync()
        {
            await _kozijnenInstaller.InstallData();

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
