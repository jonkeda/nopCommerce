using System.Threading.Tasks;
using Nop.Core;
using Nop.Services.Plugins;

namespace Nop.Plugin.Misc.Settings
{
    /// <summary>
    /// Rename this file and change to the correct type
    /// </summary>
    public class SettingsPlugin : BasePlugin
    {
        private readonly ISettingsInstaller _settingsInstaller;
        private readonly IWebHelper _webHelper;

        public SettingsPlugin(ISettingsInstaller settingsInstaller,
            IWebHelper webHelper)
        {
            _settingsInstaller = settingsInstaller;
            _webHelper = webHelper;
        }

        #region Methods

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/Settings/Update";
        }

        /// <summary>
        /// Install the plugin
        /// </summary>
        public override async Task InstallAsync()
        {
            await _settingsInstaller.ImportSettings();

            await base.InstallAsync();
        }

        /// <summary>
        /// Uninstall the plugin
        /// </summary>
        public override async Task UninstallAsync()
        {

            await base.UninstallAsync();
        }

        #endregion
        
    }
}
