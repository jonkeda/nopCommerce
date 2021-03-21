using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Nop.Services.Catalog
{
    /// <summary>
    /// Product configurator parser interface
    /// </summary>
    public partial interface IProductConfiguratorParser
    {
        Task<ProductConfiguratorParsed> ParseProductConfiguratorAsync(IFormCollection form);
    }
}
