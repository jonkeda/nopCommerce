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

        public (object model, string description, decimal price, bool isValid) Calculate(string model);

        public Type GetModelType();

        public (string model, string description, decimal price, bool isValid) CalculateToJson(string json);
    }
}