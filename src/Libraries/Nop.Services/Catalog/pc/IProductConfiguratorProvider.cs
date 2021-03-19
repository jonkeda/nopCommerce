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

        public Type GetModelType();

        public string Calculate(string json);
    }
}