using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Misc.Kozijnen.Models;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Misc.Kozijnen.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class KozijnenController : BasePluginController
    {
        #region Fields

        private readonly IKozijnenInstaller _kozijnenInstaller;
        private readonly ILocalizationService _localizationService;
        private readonly ILogger _logger;
        private readonly INotificationService _notificationService;

        #endregion

        #region Ctor

        public KozijnenController(
            IKozijnenInstaller kozijnenInstaller,
            ILocalizationService localizationService,
            ILogger logger,
            INotificationService notificationService)
        {
            _kozijnenInstaller = kozijnenInstaller;
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
            return View("~/Plugins/Nop.Plugin.Misc.Kozijnen/Views/Update.cshtml", model);
        }

        [AuthorizeAdmin]
        [Area(AreaNames.Admin)]
        [HttpPost, ActionName("Update")]
        [FormValueRequired("update")]
        public async Task<IActionResult> Configure(UpdateModel model)
        {
            if (!ModelState.IsValid)
                return await Update();

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Nop.Plugin.Misc.Kozijnen.Updated"));

            await _kozijnenInstaller.InstallData();

            return await Update();
        }

        #endregion
    }
}