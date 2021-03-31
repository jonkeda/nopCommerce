namespace Nop.Plugin.Misc.Kozijnen.Imports
{
    public interface IProductImport
    { }

    public abstract class ProductImport : IProductImport
    {
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string PictureName { get; set; }
        public bool Published { get; set; }
        public int DisplayOrder { get; set; }

        public abstract object GetConfiguration();
    }
}