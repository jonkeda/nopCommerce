namespace Nop.Plugin.Misc.Kozijnen.Imports.Languages
{
    public class LanguageImportDefinition : ILanguageImportDefinition
    {
        public LanguageImport[] LanguageFileNames { get; set; } =  { new ("NL", "Language_pack_nl_NL.xml") };
    }
}
