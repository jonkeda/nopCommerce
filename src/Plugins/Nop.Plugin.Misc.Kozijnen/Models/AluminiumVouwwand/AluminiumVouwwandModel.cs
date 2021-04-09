using Nop.Web.Areas.Admin.Models.Catalog;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Misc.Kozijnen.Models.AluminiumVouwwand
{
    public class AluminiumVouwwandModel : ProductConfiguratorBaseModel
    {
        [NopResourceDisplayName("Breedte kozijn")]
        public ProductConfiguratorField<int> BreedteKozijn { get; set; } = new();

        [NopResourceDisplayName("Hoogte kozijn")]
        public ProductConfiguratorField<int> HoogteKozijn { get; set; } = new();

        [NopResourceDisplayName("Aantal delen")]
        public ProductConfiguratorField<AantalDelen?> AantalDelen { get; set; } = new();

        [NopResourceDisplayName("Verdeling 2")]
        public ProductConfiguratorField<Verdeling2> Verdeling2 { get; set; } = new();

        [NopResourceDisplayName("Verdeling 3")]
        public ProductConfiguratorField<Verdeling3> Verdeling3 { get; set; } = new();

        [NopResourceDisplayName("Verdeling 4")]
        public ProductConfiguratorField<Verdeling4> Verdeling4 { get; set; } = new();

        [NopResourceDisplayName("Verdeling 5")]
        public ProductConfiguratorField<Verdeling5> Verdeling5 { get; set; } = new();

        [NopResourceDisplayName("Verdeling 6")]
        public ProductConfiguratorField<Verdeling6> Verdeling6 { get; set; } = new();

        [NopResourceDisplayName("Vouwrichting")]
        public ProductConfiguratorField<Vouwrichting> Vouwrichting { get; set; } = new();

        [NopResourceDisplayName("Vouwklink")]
        public ProductConfiguratorField<VouwKlink> VouwKlink { get; set; } = new();

        [NopResourceDisplayName("Type profiel")]
        public ProductConfiguratorField<TypeProfiel> TypeProfiel { get; set; } = new();

        [NopResourceDisplayName("Met aanslag")]
        public ProductConfiguratorField<MetAanslag> MetAanslag { get; set; } = new();

        [NopResourceDisplayName("Glas")]
        public ProductConfiguratorField<Glas> Glas { get; set; } = new();

        [NopResourceDisplayName("Roeden")]
        public ProductConfiguratorField<Roeden> Roeden { get; set; } = new();

        [NopResourceDisplayName("Kleur afstandhouders")]
        public ProductConfiguratorField<KleurAfstandHouders> KleurAfstandHouders { get; set; } = new();

        [NopResourceDisplayName("Structuur")]
        public ProductConfiguratorField<Structuur> Structuur { get; set; } = new();

        [NopResourceDisplayName("Kleur binnenkant")]
        public ProductConfiguratorField<string> KleurBinnenkant { get; set; } = new();

        [NopResourceDisplayName("Kleur buitenkant")]
        public ProductConfiguratorField<string> KleurBuitenkant { get; set; } = new();
    }
}
