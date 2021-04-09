using System.Threading.Tasks;

namespace Nop.Plugin.Misc.Settings
{
    public interface ISettingsInstaller
    {
        Task ImportSettings();

        Task ExportSettings();
    }
}
