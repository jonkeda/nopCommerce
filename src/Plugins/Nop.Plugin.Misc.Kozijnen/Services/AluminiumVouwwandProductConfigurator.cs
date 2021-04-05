using System.Text;
using Nop.Plugin.Misc.Kozijnen.Extensions;
using Nop.Plugin.Misc.Kozijnen.Models.AluminiumVouwwand;
using Nop.Services.Catalog;

namespace Nop.Plugin.Misc.Kozijnen.Services
{
    public class AluminiumVouwwandProductConfigurator : ProductConfiguratorBase<AluminiumVouwwandModel>
    {
        public AluminiumVouwwandProductConfigurator() 
            : base("AluminiumVouwwand")
        { }

        private const int MINIMUM_HOOGTE = 2000;
        private const int MAXIMUM_HOOGTE = 2000;


        protected override (AluminiumVouwwandModel, bool) Validate(AluminiumVouwwandModel model)
        {
            var isValid = true;

            if (model.HoogteKozijn.Value < MINIMUM_HOOGTE)
            {
                isValid = false;
                model.HoogteKozijn.Error = $"Neem contact op bij hoogtes kleiner dan {MAXIMUM_HOOGTE}";
            }

            if (model.HoogteKozijn.Value > MAXIMUM_HOOGTE)
            {
                isValid = false;
                model.HoogteKozijn.Error = $"Neem contact op bij hoogtes groter dan {MAXIMUM_HOOGTE}";
            }

            var minimumBreedte = GetMinimumBreedte(model);
            if (model.BreedteKozijn.Value < minimumBreedte)
            {
                isValid = false;
                model.BreedteKozijn.Error = $"Neem contact op bij breedtes kleiner dan {minimumBreedte}";
            }

            var maximumBreedte = GetMaximumBreedte(model);
            if (model.BreedteKozijn.Value > maximumBreedte)
            {
                isValid = false;
                model.BreedteKozijn.Error = $"Neem contact op bij breedtes groter dan {maximumBreedte}";
            }

            if (string.IsNullOrEmpty(model.KleurBinnenkant.Value))
            {
                isValid = false;
                model.KleurBinnenkant.Error = $"Vul een kleur in voor de binnenkant";
            }

            if (string.IsNullOrEmpty(model.KleurBuitenkant.Value))
            {
                isValid = false;
                model.KleurBuitenkant.Error = $"Vul een kleur in voor de buitenkant";
            }

            return (model, isValid);
        }

        private int GetMinimumBreedte(AluminiumVouwwandModel model)
        {
            switch (model.AantalDelen.Value)
            {
                case AantalDelen.Delen2:
                    return 1700;
                case AantalDelen.Delen3:
                    return 2300;
                case AantalDelen.Delen4:
                    return 3000;
                case AantalDelen.Delen5:
                    return 3800;
                case AantalDelen.Delen6:
                    return 4400;
            }

            return 0;
        }

        private int GetMaximumBreedte(AluminiumVouwwandModel model)
        {
            switch (model.AantalDelen.Value)
            {
                case AantalDelen.Delen2 : 
                    return 2050;
                case AantalDelen.Delen3:
                    return 3000;
                case AantalDelen.Delen4:
                    return 4000;
                case AantalDelen.Delen5:
                    return 5000;
                case AantalDelen.Delen6:
                    return 6000;
            }

            return 0;
        }

        protected override string CreateDescription(AluminiumVouwwandModel model)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{(int)model.AantalDelen.Value.GetValueOrDefault(AantalDelen.Delen3)} delige aluminium vouwwand");
            
            if (model.Deuren.Value != Deuren.Zonder)
            {
                sb.AddLine(model.Deuren.Value);
                sb.AddLine("Locatie loopdeuren: ", model.LocatieLoopdeuren.Value);
            }

            sb.AddLine("Schuifrichting: ", model.Schuifrichting.Value);
            sb.AddLine("Vouwrichting: ", model.Vouwrichting.Value);

            sb.AppendLine($"Breedte kozijn: {model.BreedteKozijn.Value}mm");
            sb.AppendLine($"Hoogte kozijn: {model.HoogteKozijn.Value}mm");

            sb.AddLine("Type profiel: ", model.TypeProfiel.Value);
            sb.AddLine("Met aanslag: ", model.MetAanslag.Value);

            sb.AddLine("Glas: ", model.Glas.Value);

            sb.AddLine("Roeden: ", model.Roeden.Value);

            sb.AddLine("Structuur: ", model.Structuur.Value);

            if (model.KleurBinnenkant == model.KleurBuitenkant)
            {
                sb.AppendLine($"Kleur: {model.KleurBinnenkant.Value}");
            }
            else
            {
                sb.AppendLine($"Kleur binnenkant: {model.KleurBinnenkant.Value}");
                sb.AppendLine($"Kleur buitenkant: {model.KleurBuitenkant.Value}");
            }
            sb.AddLine("Kleur afstandshouder: ", model.KleurAfstandHouders.Value);
            sb.AddLine("Vouwklink: ", model.VouwKlink.Value);

            return sb.ToString();
        }

        protected override AluminiumVouwwandModel CreateDefaultModel()
        {
            var defaultModel = new AluminiumVouwwandModel
            {
                AantalDelen = { Value = AantalDelen.Delen3 },
                HoogteKozijn = { Value = 2000 },
                BreedteKozijn = { Value = 1700 },
                KleurBinnenkant = { Value = "RAL9016" },
                KleurBuitenkant = { Value = "RAL9016" }
            };
            return defaultModel;
        }

        protected override (AluminiumVouwwandModel model, decimal price)  CalculatePrice(AluminiumVouwwandModel model)
        {
            decimal price = (model.BreedteKozijn.Value * model.HoogteKozijn.Value) / 10000;
            return (model, price);
        }
    }

}
