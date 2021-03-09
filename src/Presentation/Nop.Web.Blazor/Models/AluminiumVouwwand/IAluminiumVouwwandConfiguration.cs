namespace Nop.Web.Models.AluminiumVouwwand
{
    public interface IAluminiumVouwwandConfigurationCost : IConfigurationCost
    {
        double PerDeel { get; set; }

    }

    public interface IAluminiumVouwwandConfiguration : IConfiguration
    {
        AantalDelen AantalDelen { get; set; }
        bool MetDeur { get; set; }
        Deuren Deuren { get; set; }
        Schuifrichting SchuifRichting { get; set; }
        Vouwrichting Vouwrichting { get; set; }
        LocatieLoopdeuren LocatieLoopdeuren { get; set; }
        int BreedteKozijn { get; set; }
        int HoogteKozijn { get; set; }
        TypeProfiel TypeProfiel { get; set; }
        MetAanslag MetAanslag { get; set; }
        Glas Glas { get; set; }
        Roeden Roeden { get; set; }
        Structuur Structuur { get; set; }
        string KleurBinnenkant { get; set; }
        string KleurBuitenkant { get; set; }
        KleurAfstandHouders KleurAfstandHouders { get; set; }
        VouwKlink VouwKlink { get; set; }
    }

    public enum VouwKlink
    {
        MetCilinder,
        ZonderCilinder
    }

    public enum KleurAfstandHouders
    {
        Zilver,
        Zwart,
        Witte,
        LichtGrijs,
        Grijs,
        LichtBruin,
        Bruin
    }

    public enum Vouwrichting
    {
        NaarBuiten,
        NaarBinnen
    }

    public enum Schuifrichting
    {
        NaarRechts,
        NaarLinks
    }
}