namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// Definition of a configured product
    /// PCFG
    /// </summary>
    public interface IProductConfiguration
    {
        /// <summary>
        /// Gets or sets the configurationdata of the configured product. This is defined in JSON
        /// PCFG
        /// </summary>
        public string Configuration { get; set; }

        /// <summary>
        /// Gets or sets the readable text of the configured product
        /// PCFG
        /// </summary>
        public string ConfigurationDescription { get; set; }

        /// <summary>
        /// Gets or sets the picture id of the configured product
        /// PCFG
        /// </summary>
        public string ConfigurationPictureId { get; set; }
    }
}