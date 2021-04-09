using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Configuration;
using Nop.Core.Domain.Media;
using Nop.Core.Infrastructure;
using Nop.Plugin.Misc.Settings.Data;
using Nop.Plugin.Misc.Settings.Extensions;
using Nop.Services.Configuration;

namespace Nop.Plugin.Misc.Settings
{
    /// <summary>
    /// Rename this file and change to the correct type
    /// </summary>
    public class SettingsInstaller : ISettingsInstaller
    {
        private readonly ITypeFinder _typeFinder;
        private readonly ISettingService _settingService;

        #region Fields

        private const string SAVE_PATH = @"C:\Azure\nopCommerce\src\Plugins\Nop.Plugin.Misc.Settings\Data";

        #endregion

        #region Constructor

        public SettingsInstaller(
            ITypeFinder typeFinder,
            ISettingService settingService)
        {
            _typeFinder = typeFinder;
            _settingService = settingService;
        }

        #endregion

        #region Catalogs

        public async Task ImportSettings()
        {
            foreach (var type in _typeFinder.FindClassesOfType(typeof(ISettings)))
            {
                var text = typeof(aaaSettingsLocation).ReadAsString(type.Name);
                if (text != null)
                {
                    try
                    {
                        var settings = XmlSerializerEx.LoadFromText(text, type);
                        await _settingService.SaveSettingAsync(type, settings);
                    }
                    catch 
                    { }
                }
            }
        }
   

        public async Task ExportSettings()
        {
            if (!Directory.Exists(SAVE_PATH))
            {
                return;
            }
            foreach (var type in _typeFinder.FindClassesOfType(typeof(ISettings)))
            {
                try
                {
                    var settings = await _settingService.LoadSettingAsync(type);
                    XmlSerializerEx.SaveObject(Path.Combine(SAVE_PATH, $"{type.Name}.xml"), settings);
                }
                catch (Exception e)
                {

                }
            }
        }

        #endregion
    }
}