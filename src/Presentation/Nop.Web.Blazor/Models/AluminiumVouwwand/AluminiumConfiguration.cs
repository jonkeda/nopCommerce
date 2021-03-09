namespace Nop.Web.Models.AluminiumVouwwand
{
    public class AluminiumConfiguration : IAluminiumVouwwandConfiguration
    {
        public AantalDelen AantalDelen { get; set; }

        public bool MetDeur { get; set; }

        public Deuren Deuren { get; set; }

        public Schuifrichting SchuifRichting { get; set; }

        public Vouwrichting Vouwrichting { get; set; }

        public LocatieLoopdeuren LocatieLoopdeuren { get; set; }

        public int BreedteKozijn { get; set; }

        public int HoogteKozijn { get; set; }

        public TypeProfiel TypeProfiel { get; set; }

        public MetAanslag MetAanslag { get; set; }

        public Glas Glas { get; set; }

        public Roeden Roeden { get; set; }

        public Structuur Structuur { get; set; }

        public string KleurBinnenkant { get; set; }

        public string KleurBuitenkant { get; set; }

        public KleurAfstandHouders KleurAfstandHouders { get; set; }

        public VouwKlink VouwKlink { get; set; }
    }
}
