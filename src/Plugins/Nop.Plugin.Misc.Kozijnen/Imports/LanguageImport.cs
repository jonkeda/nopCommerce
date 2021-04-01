namespace Nop.Plugin.Misc.Kozijnen.Imports
{
    public class LanguageImport
    {
        public LanguageImport(string name, string fileName)
        {
            Name = name;
            FileName = fileName;
        }

        public string Name { get; set; }
        public string FileName { get; set; }
    }
}