using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Misc.Settings.Models;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Misc.Settings.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class SettingsController : BasePluginController
    {
        #region Fields

        private readonly ISettingsInstaller _settingsInstaller;
        private readonly ILocalizationService _localizationService;
        private readonly ILogger _logger;
        private readonly INotificationService _notificationService;

        #endregion

        #region Ctor

        public SettingsController(
            ISettingsInstaller settingsInstaller,
            ILocalizationService localizationService,
            ILogger logger,
            INotificationService notificationService)
        {
            _settingsInstaller = settingsInstaller;
            _localizationService = localizationService;
            _logger = logger;
            _notificationService = notificationService;
        }

        #endregion
        
        #region Methods

        [AuthorizeAdmin]
        [Area(AreaNames.Admin)]
        public async Task<IActionResult> Update()
        {
            var model = new UpdateModel();
            return View("~/Plugins/Nop.Plugin.Misc.Settings/Views/Update.cshtml", model);
        }

        [AuthorizeAdmin]
        [Area(AreaNames.Admin)]
        [HttpPost, ActionName("Update")]
        [FormValueRequired("update")]
        public async Task<IActionResult> Update(UpdateModel model)
        {
            if (!ModelState.IsValid)
                return await Update();

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Nop.Plugin.Misc.Settings.Updated"));

            await _settingsInstaller.ImportSettings();

            return await Update();
        }

        [AuthorizeAdmin]
        [Area(AreaNames.Admin)]
        [HttpPost, ActionName("Export")]
        [FormValueRequired("export")]
        public async Task<IActionResult> Export(UpdateModel model)
        {
            if (!ModelState.IsValid)
                return await Update();

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Nop.Plugin.Misc.Settings.Updated"));

            await _settingsInstaller.ExportSettings();

            return await Update();
        }

        #endregion
    }
}