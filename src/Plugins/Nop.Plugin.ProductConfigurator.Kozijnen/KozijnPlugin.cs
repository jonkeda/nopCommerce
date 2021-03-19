using Nop.Core;
using Nop.Services.Catalog;
using Nop.Services.Common;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using System.Threading.Tasks;

namespace Nop.Plugin.ProductConfigurator.Kozijnen
{
    /// <summary>
    /// Represents the Kozijn plugin
    /// </summary>
    public class KozijnPlugin : BasePlugin, IProductConfiguratorPlugin
    {
        #region Fields

        private readonly IGenericAttributeService _genericAttributeService;
        private readonly ILocalizationService _localizationService;
        private readonly IWebHelper _webHelper;

        #endregion

        #region Ctor

        public KozijnPlugin(
            IGenericAttributeService genericAttributeService,
            ILocalizationService localizationService,
            IWebHelper webHelper)
        {
            _genericAttributeService = genericAttributeService;
            _localizationService = localizationService;
            _webHelper = webHelper;
        }

        #endregion

            #region Methods

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/Kozijnen/Configure";
        }

        /// <summary>
        /// Install the plugin
        /// </summary>
        public override async Task InstallAsync()
        {

            //locales
            //await _localizationService.AddLocaleResourceAsync(new Dictionary<string, string>
            //{
            //    ["Plugins.Misc.Sendinblue.AccountInfo"] = "Account info",
            //});

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
