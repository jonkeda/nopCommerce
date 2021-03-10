using Nop.Core.Domain.Common;
using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// Represents a product configurator
    /// PCFG
    /// </summary>
    public partial class ProductConfigurator : BaseEntity, ILocalizedEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the short description
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets the full description
        /// </summary>
        public string FullDescription { get; set; }

        /// <summary>
        /// Gets or sets the admin comment
        /// </summary>
        public string AdminComment { get; set; }

        /// <summary>
        /// Gets or sets the meta keywords
        /// </summary>
        public string MetaKeywords { get; set; }

        /// <summary>
        /// Gets or sets the meta description
        /// </summary>
        public string MetaDescription { get; set; }

        /// <summary>
        /// Gets or sets the meta title
        /// </summary>
        public string MetaTitle { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity has been deleted
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Gets or sets the definition in JSON
        /// </summary>
        public string Definition { get; set; }

        /// <summary>
        /// Gets or sets the attributes in JSON
        /// </summary>
        public string Attributes { get; set; }

        /// <summary>
        /// Gets or sets the Full Class Name of the product configurator
        /// </summary>
        public string FullClassName { get; set; }

        /// <summary>
        /// Gets or sets the Route Name of the product configurator
        /// </summary>
        public string RouteName { get; set; }

    }
}