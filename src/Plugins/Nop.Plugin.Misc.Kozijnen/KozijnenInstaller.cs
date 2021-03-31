using System.Threading.Tasks;
using Nop.Plugin.Misc.Kozijnen.Imports;
using Nop.Plugin.Misc.Kozijnen.Imports.Vouwwanden.AluminiumVouwwanden;

namespace Nop.Plugin.Misc.Kozijnen
{
    /// <summary>
    /// Rename this file and change to the correct type
    /// </summary>
    public class KozijnenInstaller : IKozijnenInstaller
    {
        #region Fields

        private readonly IImporter _importer;


        #endregion

        #region Constructor

        public KozijnenInstaller(IImporter importer)
        {
            _importer = importer;
        }

        #endregion

        #region Catalogs

        public async Task InstallData()
        {
            await _importer.Import(new CategoryImportDefinition());

            await _importer.Import(new AluminiumVouwwandenImportDefinition());
        }

        #endregion
    }
}