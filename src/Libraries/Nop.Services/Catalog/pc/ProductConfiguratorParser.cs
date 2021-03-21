using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Nop.Services.Catalog
{
    public class ProductConfiguratorParser : IProductConfiguratorParser
    {
        private readonly IProductConfiguratorPluginManager _productConfiguratorPluginManager;

        public ProductConfiguratorParser(IProductConfiguratorPluginManager productConfiguratorPluginManager)
        {
            _productConfiguratorPluginManager = productConfiguratorPluginManager;
        }

        public async Task<ProductConfiguratorParsed> ParseProductConfiguratorAsync(IFormCollection form)
        {
            var json = CreateConfigurationJson(form);

            var configuratorId = int.Parse(form["ConfiguratorId"]);
            object configuratorModel;
            decimal price;
            string description;
            bool isValid;

            var provider = await _productConfiguratorPluginManager.GetProductConfiguratorProvider(configuratorId);

            (configuratorModel, description, price, isValid) = provider.Calculate(json);

            return new ProductConfiguratorParsed(configuratorId, json, configuratorModel, description, price, isValid);
        }

        private string CreateConfigurationJson(IFormCollection form)
        {
            var sb = new StringBuilder();
            sb.Append("{");
            var first = true;
            foreach (var key in form.Keys)
            {
                if (key.EndsWith(".Value"))
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        sb.Append(",");
                    }
                    var name = key.Substring(0, key.IndexOf(".", StringComparison.Ordinal));
                    sb.Append($@"""{name}"": {{""Value"":""{GetValue(form,key)}""}}");
                }
            }
            sb.Append("}");
            return sb.ToString();
        }

        private string GetValue(IFormCollection form, string key)
        {
            string value = form[key];
            if (value == "true,false")
            {
                return "true";
            }

            return value;
        }
    }
}