namespace Nop.Plugin.Misc.Kozijnen.Imports.Languages
{
    public class LanguageImportDefinition : ILanguageImportDefinition
    {
        public LanguageImport[] LanguageFileNames { get; set; } =  { new ("Nederlands", "Language_pack.nl-NL.xml") };
    }
}
