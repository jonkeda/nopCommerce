using Nop.Plugin.ProductConfigurator.Kozijnen.Models.AluminiumVouwwand;
using Nop.Services.Catalog;

namespace Nop.Plugin.ProductConfigurator.Kozijnen.Services
{
    public class AluminiumVouwwandProductConfigurator : ProductConfiguratorBase<AluminiumVouwwandModel>
    {
        public AluminiumVouwwandProductConfigurator() : base("AluminiumVouwwand")
        { }

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

        protected override AluminiumVouwwandModel Calculate(AluminiumVouwwandModel model)
        {
            model.Price.Value = model.BreedteKozijn.Value + model.HoogteKozijn.Value;
            return model;
        }
    }

}
