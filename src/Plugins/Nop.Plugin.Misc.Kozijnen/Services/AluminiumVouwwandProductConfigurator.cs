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

        protected override (AluminiumVouwwandModel, bool) Validate(AluminiumVouwwandModel model)
        {
            var isValid = true;

            return (model, isValid);
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
