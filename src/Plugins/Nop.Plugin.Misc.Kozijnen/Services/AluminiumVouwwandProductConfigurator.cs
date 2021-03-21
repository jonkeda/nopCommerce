﻿using Nop.Plugin.Misc.Kozijnen.Models.AluminiumVouwwand;
using Nop.Services.Catalog;

namespace Nop.Plugin.Misc.Kozijnen.Services
{
    public class AluminiumVouwwandProductConfigurator : ProductConfiguratorBase<AluminiumVouwwandModel>
    {
        public AluminiumVouwwandProductConfigurator() 
            : base("AluminiumVouwwand")
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

        protected override (AluminiumVouwwandModel model, decimal price)  Calculate(AluminiumVouwwandModel model)
        {
            decimal price = (model.BreedteKozijn.Value * model.HoogteKozijn.Value) / 10000;
            return (model, price);
        }
    }

}
