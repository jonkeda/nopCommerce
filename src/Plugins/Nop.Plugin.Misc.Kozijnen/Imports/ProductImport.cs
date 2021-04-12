namespace Nop.Plugin.Misc.Kozijnen.Imports
{
    public abstract class ProductImport : IProductImport
    {
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string PictureName { get; set; }
        public bool Published { get; set; }
        public int DisplayOrder { get; set; }
        public bool ShowOnHomepage { get; set; }

        public abstract object GetConfiguration();
    }

    public class PictureImport
    {
        public PictureImport()
        {
        }

        public PictureImport(string idName, string name)
        {
            IdName = idName;
            Name = name;
        }

        public string IdName { get; set; }
        public string Name { get; set; }

    }
}