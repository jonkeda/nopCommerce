using System;
using System.Text;
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
            
            return sb.ToString();
        }

        protected override AluminiumVouwwandModel CreateDefaultModel()
        {
            var defaultModel = new AluminiumVouwwandModel
            {
                AantalDelen = { Value = AantalDelen.Delen3 },
                HoogteKozijn = { Value = 2000 },
                BreedteKozijn = { Value = 1700 }
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
