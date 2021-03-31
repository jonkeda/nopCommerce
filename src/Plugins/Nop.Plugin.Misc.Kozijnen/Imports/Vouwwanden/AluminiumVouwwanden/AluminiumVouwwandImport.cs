using System.Collections.Generic;
using System.Xml.Serialization;
using Nop.Plugin.Misc.Kozijnen.Models.AluminiumVouwwand;

namespace Nop.Plugin.Misc.Kozijnen.Imports.Vouwwanden.AluminiumVouwwanden
{
    [XmlRoot("Imports")]
    public class AluminiumVouwwandImports : IProductImports
    {
        [XmlElement("Products")]
        public AluminiumVouwwandImportCollection Products { get; set; } = new AluminiumVouwwandImportCollection();

        public IEnumerable<ProductImport> GetProducts()
        {
            return Products;
        }
    }

    public class AluminiumVouwwandImport : ProductImport
    {
        public int BreedteKozijn { get; set; }

        public int HoogteKozijn { get; set; }

        public AantalDelen? AantalDelen { get; set; } = Models.AluminiumVouwwand.AantalDelen.Delen2;

        public Schuifrichting Schuifrichting { get; set; }

        public Vouwrichting Vouwrichting { get; set; }

        public VouwKlink VouwKlink { get; set; }

        public bool MetDeur { get; set; } = new ();

        public Deuren Deuren { get; set; }

        public LocatieLoopdeuren LocatieLoopdeuren { get; set; }

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
                Schuifrichting = Schuifrichting,
                Vouwrichting = Vouwrichting,
                VouwKlink = VouwKlink,
                MetDeur = MetDeur,
                Deuren = Deuren,
                LocatieLoopdeuren = LocatieLoopdeuren,
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
