using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Catalog;

namespace Nop.Services.Catalog
{
    /// <summary>
    /// ProductConfigurator service
    /// </summary>
    public partial interface IProductConfiguratorService
    {
        /// <summary>
        /// Get the product configurator
        /// </summary>
        /// <param name="fullClassName">Full class name of the product configurator</param>
        /// <returns>Entity entry</returns>
        Task<ProductConfigurator> GetByFullClassNameAsync(string fullClassName);

        /// <summary>
        /// Deletes a ProductConfigurator
        /// </summary>
        /// <param name="productConfigurator">ProductConfigurator</param>
        Task DeleteProductConfiguratorAsync(ProductConfigurator productConfigurator);

        /// <summary>
        /// Delete ProductConfigurators
        /// </summary>
        /// <param name="productConfigurators">ProductConfigurators</param>
        Task DeleteProductConfiguratorsAsync(IList<ProductConfigurator> productConfigurators);

        /// <summary>
        /// Gets all ProductConfigurators
        /// </summary>
        /// <param name="productConfiguratorName">ProductConfigurator name</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>ProductConfigurators</returns>
        Task<IPagedList<ProductConfigurator>> GetAllProductConfiguratorsAsync(string productConfiguratorName = "",
            int pageIndex = 0,
            int pageSize = int.MaxValue);

        /// <summary>
        /// Gets a ProductConfigurator
        /// </summary>
        /// <param name="productConfiguratorId">ProductConfigurator identifier</param>
        /// <returns>ProductConfigurator</returns>
        Task<ProductConfigurator> GetProductConfiguratorByIdAsync(int productConfiguratorId);

        /// <summary>
        /// Gets ProductConfigurators by identifier
        /// </summary>
        /// <param name="productConfiguratorIds">ProductConfigurator identifiers</param>
        /// <returns>ProductConfigurators</returns>
        Task<IList<ProductConfigurator>> GetProductConfiguratorsByIdsAsync(int[] productConfiguratorIds);

        /// <summary>
        /// Inserts a ProductConfigurator
        /// </summary>
        /// <param name="productConfigurator">ProductConfigurator</param>
        Task InsertProductConfiguratorAsync(ProductConfigurator productConfigurator);

        /// <summary>
        /// Updates the ProductConfigurator
        /// </summary>
        /// <param name="productConfigurator">ProductConfigurator</param>
        Task UpdateProductConfiguratorAsync(ProductConfigurator productConfigurator);
    }
}