namespace Nop.Plugin.Misc.Kozijnen.Imports
{
    public interface ILanguageImportDefinition : IImportDefinition
    {
        public LanguageImport[] LanguageFileNames { get; set; }
    }
}