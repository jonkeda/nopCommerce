using Nop.Plugin.Misc.Kozijnen.Models.AluminiumVouwwand;

namespace Nop.Plugin.Misc.Kozijnen.Imports.Vouwwanden.AluminiumVouwwanden
{
    public class AluminiumVouwwandImport : ProductImport
    {
        public int BreedteKozijn { get; set; }

        public int HoogteKozijn { get; set; }

        public AantalDelen? AantalDelen { get; set; } = Models.AluminiumVouwwand.AantalDelen.Delen2;

        public Verdeling2 Verdeling2 { get; set; }

        public Verdeling3 Verdeling3 { get; set; }

        public Verdeling4 Verdeling4 { get; set; }

        public Verdeling5 Verdeling5 { get; set; }

        public Verdeling6 Verdeling6 { get; set; }

        public Vouwrichting Vouwrichting { get; set; }

        public VouwKlink VouwKlink { get; set; }

        public TypeProfiel TypeProfiel { get; set; }

        public MetAanslag MetAanslag { get; set; }

        public Glas Glas { get; set; }

        public Roeden Roeden { get; set; }

        public KleurAfstandHouders KleurAfstandHouders { get; set; }

        public Structuur Structuur { get; set; }

        public string KleurBinnenkant { get; set; } = "RAL9010";

        public string KleurBuitenkant { get; set; } = "RAL9010";

        public AluminiumVouwwandModel CreateModel()
        {
            var model = new AluminiumVouwwandModel
            {
                BreedteKozijn = BreedteKozijn,
                HoogteKozijn = HoogteKozijn,
                AantalDelen = AantalDelen,
                Verdeling2 = Verdeling2,
                Verdeling3 = Verdeling3,
                Verdeling4 = Verdeling4,
                Verdeling5 = Verdeling5,
                Verdeling6 = Verdeling6,
                Vouwrichting = Vouwrichting,
                VouwKlink = VouwKlink,
                TypeProfiel = TypeProfiel,
                MetAanslag = MetAanslag,
                Glas = Glas,
                Roeden = Roeden,
                KleurAfstandHouders = KleurAfstandHouders,
                Structuur = Structuur,
                KleurBinnenkant = KleurBinnenkant,
                KleurBuitenkant = KleurBuitenkant
            };

            return model;
        }

        public override object GetConfiguration()
        {
            return CreateModel();
        }
    }
}
