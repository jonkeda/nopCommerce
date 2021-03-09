using Nop.Web.Models.AluminiumVouwwand;

namespace Nop.Web.ViewModels.AluminiumVouwwand
{
    public class AluminiumVouwwandViewModel : ConfigurationViewModel, IAluminiumVouwwandConfiguration, IAluminiumVouwwandConfigurationCost
    {
        public string SvgImage { get; set; } = @"<svg id=""eovg371eo6h1"" xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" viewBox=""0 0 280 300"" shape-rendering=""geometricPrecision"" text-rendering=""geometricPrecision""><style><![CDATA[#eovg371eo6h8_to {animation: eovg371eo6h8_to__to 4000ms linear infinite normal forwards}@keyframes eovg371eo6h8_to__to { 0% {transform: translate(84.500000px,150px)} 25% {transform: translate(195.500000px,150px)} 50% {transform: translate(195.500000px,149.800000px)} 75% {transform: translate(84.500000px,149.800000px)} 100% {transform: translate(84.500000px,150px)} }]]></style><g id=""eovg371eo6h2"" transform=""matrix(1 0 0 1 0 0.00000000000034)""><g id=""eovg371eo6h3""><rect id=""eovg371eo6h4"" width=""230"" height=""250"" rx=""0"" ry=""0"" transform=""matrix(1 0 0 1 25 25)"" fill=""rgb(0,0,0)"" stroke=""rgb(0,0,0)"" stroke-width=""1""/><rect id=""eovg371eo6h5"" width=""228"" height=""248"" rx=""0"" ry=""0"" transform=""matrix(1 0 0 1 26 26)"" fill=""rgb(102,102,102)"" stroke=""rgb(0,0,0)"" stroke-width=""1""/><rect id=""eovg371eo6h6"" width=""214"" height=""234"" rx=""0"" ry=""0"" transform=""matrix(1 0 0 1 33 33)"" fill=""rgb(0,0,0)"" stroke=""rgb(0,0,0)"" stroke-width=""1""/><rect id=""eovg371eo6h7"" width=""205"" height=""224"" rx=""0"" ry=""0"" transform=""matrix(1 0 0 1 37.50000000000000 37.80000000000000)"" fill=""rgb(255,255,255)"" stroke=""rgb(0,0,0)"" stroke-width=""1""/></g><g id=""eovg371eo6h8_to"" transform=""translate(84.500000,150)""><g id=""eovg371eo6h8"" transform=""translate(-87,-149.799992)""><rect id=""eovg371eo6h9"" width=""110"" height=""238"" rx=""0"" ry=""0"" transform=""matrix(1 0 0 1 31.50000000000000 30.80000000000000)"" fill=""rgb(0,0,0)"" stroke=""rgb(0,0,0)"" stroke-width=""1""/><rect id=""eovg371eo6h10"" width=""111"" height=""238"" rx=""0"" ry=""0"" transform=""matrix(1 0 0 1 31.50000000000000 30.80000000000000)"" fill=""rgb(203,216,216)"" stroke=""rgb(0,0,0)"" stroke-width=""1""/><rect id=""eovg371eo6h11"" width=""91"" height=""219"" rx=""0"" ry=""0"" transform=""matrix(1 0 0 1 41.50000000000000 40.80000000000000)"" fill=""rgb(0,0,0)"" stroke=""rgb(0,0,0)"" stroke-width=""1""/><rect id=""eovg371eo6h12"" width=""92"" height=""222"" rx=""0"" ry=""0"" transform=""matrix(1 0 0 1 40.50000000000000 38.80000000000000)"" fill=""rgb(255,255,255)"" stroke=""rgb(0,0,0)"" stroke-width=""1""/><ellipse id=""eovg371eo6h13"" rx=""2.500000"" ry=""12.500000"" transform=""matrix(1 0 0 1 36 145.30000000000001)"" fill=""rgb(231,237,168)"" stroke=""rgb(0,0,0)"" stroke-width=""1""/></g></g></g></svg>";

        private AantalDelen _aantalDelen = AantalDelen.Delen3;
        private Deuren _deuren = Deuren.Enkel;
        private Schuifrichting _schuifRichting = Schuifrichting.NaarLinks;
        private Vouwrichting _vouwrichting = Vouwrichting.NaarBinnen ;
        private LocatieLoopdeuren _locatieLoopdeuren = LocatieLoopdeuren.Links ;
        private int _breedteKozijn = 2400;
        private int _hoogteKozijn = 2000;
        private TypeProfiel _typeProfiel = TypeProfiel.AluminiumHarmonicasysteem77mmDiep;
        private MetAanslag _metAanslag = MetAanslag.MetAanslag;
        private Glas _glas = Glas.HrPpDubbelGlas;
        private Roeden _roeden = Roeden.Geen;
        private Structuur _structuur = Structuur.GladdeLak;
        private string _kleurBinnenkant = "RAL9010";
        private string _kleurBuitenkant = "RAL9010";
        private KleurAfstandHouders _kleurAfstandHouders = KleurAfstandHouders.Zilver;
        private VouwKlink _vouwKlink = VouwKlink.ZonderCilinder;
        private double _perDeel = 750;
        private bool _metDeur;

        #region Configuration

        public AantalDelen AantalDelen
        {
            get => _aantalDelen;
            set => CalculateProperty(ref _aantalDelen, value);
        }

        public bool MetDeur
        {
            get => _metDeur;
            set => CalculateProperty(ref _metDeur, value);
        }

        public Deuren Deuren
        {
            get => _deuren;
            set => CalculateProperty(ref _deuren, value);
        }

        public Schuifrichting SchuifRichting
        {
            get => _schuifRichting;
            set => CalculateProperty(ref _schuifRichting, value);
        }

        public Vouwrichting Vouwrichting
        {
            get => _vouwrichting;
            set => CalculateProperty(ref _vouwrichting, value);
        }

        public LocatieLoopdeuren LocatieLoopdeuren
        {
            get => _locatieLoopdeuren;
            set => CalculateProperty(ref _locatieLoopdeuren, value);
        }

        public int BreedteKozijn
        {
            get => _breedteKozijn;
            set => CalculateProperty(ref _breedteKozijn, value);
        }

        public int HoogteKozijn
        {
            get => _hoogteKozijn;
            set => CalculateProperty(ref _hoogteKozijn, value);
        }

        public TypeProfiel TypeProfiel
        {
            get => _typeProfiel;
            set => CalculateProperty(ref _typeProfiel, value);
        }

        public MetAanslag MetAanslag
        {
            get => _metAanslag;
            set => CalculateProperty(ref _metAanslag, value);
        }

        public Glas Glas
        {
            get => _glas;
            set => CalculateProperty(ref _glas, value);
        }

        public Roeden Roeden
        {
            get => _roeden;
            set => CalculateProperty(ref _roeden, value);
        }

        public Structuur Structuur
        {
            get => _structuur;
            set => CalculateProperty(ref _structuur, value);
        }

        public string KleurBinnenkant
        {
            get => _kleurBinnenkant;
            set => CalculateProperty(ref _kleurBinnenkant, value);
        }

        public string KleurBuitenkant
        {
            get => _kleurBuitenkant;
            set => CalculateProperty(ref _kleurBuitenkant, value);
        }

        public KleurAfstandHouders KleurAfstandHouders
        {
            get => _kleurAfstandHouders;
            set => CalculateProperty(ref _kleurAfstandHouders, value);
        }

        public VouwKlink VouwKlink
        {
            get => _vouwKlink;
            set => CalculateProperty(ref _vouwKlink, value);
        }

        #endregion

        #region Validations

        public int MinBreedteKozijn { get; set; }
        public int MaxBreedteKozijn { get; set; }
        public string BreedteKozijnMessage { get; set; }

        public int MinHoogteKozijn { get; set; }
        public int MaxHoogteKozijn { get; set; }
        public string HoogteKozijnMessage { get; set; }

        #endregion

        #region Configuration Cost

        public double PerDeel
        {
            get => _perDeel;
            set => CalculateProperty(ref _perDeel, value);
        }

        #endregion

        #region Calculate

        protected override bool ValidateConfiguration()
        {
            GetMinimaleEnMaximaleHoogte();
            GetMinimaleEnMaximaleBreedte();

            bool isValid = ValidateBreedte();
            isValid &= ValidateHoogte();

            SetDeuren();

            return isValid;
        }

        private void SetDeuren()
        {
            if (AantalDelen == AantalDelen.Delen2)
            {
                Deuren = Deuren.Zonder;
            }
            else if (AantalDelen == AantalDelen.Delen3)
            {
                Deuren = MetDeur ? Deuren.Enkel : Deuren.Zonder;
            }
            else if (AantalDelen == AantalDelen.Delen4)
            {
                Deuren = MetDeur ? Deuren.Dubbel : Deuren.Zonder;
            }
            else if (AantalDelen == AantalDelen.Delen5)
            {
                Deuren = MetDeur ? Deuren.Enkel : Deuren.Zonder;
            }
            else if (AantalDelen == AantalDelen.Delen6)
            {
                Deuren = MetDeur ? Deuren.Dubbel : Deuren.Zonder;
            }
        }

        private bool ValidateBreedte()
        {
            BreedteKozijnMessage = null;
            if (BreedteKozijn < MinBreedteKozijn)
            {
                BreedteKozijnMessage = $"Neem contact op voor kozijnen kleiner dan {MinBreedteKozijn}";
                return false;
            }
            if (BreedteKozijn > MaxBreedteKozijn)
            {
                BreedteKozijnMessage = $"Neem contact op voor kozijnen groter dan {MaxBreedteKozijn}";
                return false;
            }
            return true;
        }

        private bool ValidateHoogte()
        {
            HoogteKozijnMessage = null;
            if (HoogteKozijn < MinHoogteKozijn)
            {
                HoogteKozijnMessage = $"Neem contact op voor kozijnen kleiner dan {MinHoogteKozijn}";
                return false;
            }
            if (HoogteKozijn > MaxHoogteKozijn)
            {
                HoogteKozijnMessage = $"Neem contact op voor kozijnen groter dan {MaxHoogteKozijn}";
                return false;
            }
            return true;
        }

        private void GetMinimaleEnMaximaleBreedte()
        {
            if (AantalDelen == AantalDelen.Delen2)
            {
                MinBreedteKozijn = 1700;
                MaxBreedteKozijn = 2050;
            }
            else if (AantalDelen == AantalDelen.Delen3)
            {
                MinBreedteKozijn = 2300;
                MaxBreedteKozijn = 3000;
            }
            else if (AantalDelen == AantalDelen.Delen4)
            {
                MinBreedteKozijn = 3000;
                MaxBreedteKozijn = 4000;
            }
            else if (AantalDelen == AantalDelen.Delen5)
            {
                MinBreedteKozijn = 3800;
                MaxBreedteKozijn = 5000;
            }
            else if (AantalDelen == AantalDelen.Delen6)
            {
                MinBreedteKozijn = 4400;
                MaxBreedteKozijn = 5900;
            }
        }

        private void GetMinimaleEnMaximaleHoogte()
        {
            MinHoogteKozijn = 2000;
            MaxHoogteKozijn = 2690;
        }

        protected override void CalculateConfiguration(out double price)
        {
            price = (int)AantalDelen * PerDeel;

        }

        #endregion

    }
}