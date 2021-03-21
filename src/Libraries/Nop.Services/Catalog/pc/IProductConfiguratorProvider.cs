using System;

namespace Nop.Services.Catalog
{
    /// <summary>
    /// ProductConfigurator
    /// </summary>
    public partial interface IProductConfiguratorProvider
    {
        public string GetViewName();

        public object GetDefaultModel();

        public (object model, decimal price) Calculate(string model);

        public Type GetModelType();

        public (string model, decimal price) CalculateToJson(string json);
    }
}