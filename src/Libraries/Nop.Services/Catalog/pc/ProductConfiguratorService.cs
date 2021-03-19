using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Data;

namespace Nop.Services.Catalog
{
    /// <summary>
    /// ProductConfigurator service
    /// </summary>
    public partial class ProductConfiguratorService : IProductConfiguratorService
    {
        #region Fields

        private readonly IRepository<ProductConfigurator> _productConfiguratorRepository;

        #endregion

        #region Ctor

        public ProductConfiguratorService(IRepository<ProductConfigurator> productConfiguratorRepository)
        {
            _productConfiguratorRepository = productConfiguratorRepository;
        }

        #endregion

        #region Methods

        public async Task<ProductConfigurator> GetByFullClassNameAsync(string fullClassName)
        {
            var list = await _productConfiguratorRepository
                .GetAllAsync(p => p.Where(c => c.FullClassName == fullClassName));
            return list.FirstOrDefault();
        }

        /// <summary>
        /// Deletes a ProductConfigurator
        /// </summary>
        /// <param name="productConfigurator">ProductConfigurator</param>
        public virtual async Task DeleteProductConfiguratorAsync(ProductConfigurator productConfigurator)
        {
            await _productConfiguratorRepository.DeleteAsync(productConfigurator);
        }

        /// <summary>
        /// Delete ProductConfigurators
        /// </summary>
        /// <param name="productConfigurators">ProductConfigurators</param>
        public virtual async Task DeleteProductConfiguratorsAsync(IList<ProductConfigurator> productConfigurators)
        {
            await _productConfiguratorRepository.DeleteAsync(productConfigurators);
        }

        /// <summary>
        /// Gets all ProductConfigurators
        /// </summary>
        /// <param name="productConfiguratorName">ProductConfigurator name</param>
        /// <param name="storeId">Store identifier; 0 if you want to get all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <param name="overridePublished">
        /// null - process "Published" property according to "showHidden" parameter
        /// true - load only "Published" products
        /// false - load only "Unpublished" products
        /// </param>
        /// <returns>ProductConfigurators</returns>
        public virtual async Task<IPagedList<ProductConfigurator>> GetAllProductConfiguratorsAsync(string productConfiguratorName = "",
            int pageIndex = 0,
            int pageSize = int.MaxValue)
        {
            return await _productConfiguratorRepository.GetAllPagedAsync(async query =>
            {
                query = query.Where(m => !m.Deleted);

                if (!string.IsNullOrWhiteSpace(productConfiguratorName))
                    query = query.Where(m => m.Name.Contains(productConfiguratorName));

                return query.OrderBy(m => m.Id);
            }, pageIndex, pageSize);
        }

        /// <summary>
        /// Gets a ProductConfigurator
        /// </summary>
        /// <param name="productConfiguratorId">ProductConfigurator identifier</param>
        /// <returns>ProductConfigurator</returns>
        public virtual async Task<ProductConfigurator> GetProductConfiguratorByIdAsync(int productConfiguratorId)
        {
            return await _productConfiguratorRepository.GetByIdAsync(productConfiguratorId, cache => default);
        }

        /// <summary>
        /// Gets ProductConfigurators by identifier
        /// </summary>
        /// <param name="productConfiguratorIds">ProductConfigurator identifiers</param>
        /// <returns>ProductConfigurators</returns>
        public virtual async Task<IList<ProductConfigurator>> GetProductConfiguratorsByIdsAsync(int[] productConfiguratorIds)
        {
            return await _productConfiguratorRepository.GetByIdsAsync(productConfiguratorIds, includeDeleted: false);
        }

        /// <summary>
        /// Inserts a ProductConfigurator
        /// </summary>
        /// <param name="productConfigurator">ProductConfigurator</param>
        public virtual async Task InsertProductConfiguratorAsync(ProductConfigurator productConfigurator)
        {
            await _productConfiguratorRepository.InsertAsync(productConfigurator);
        }

        /// <summary>
        /// Updates the ProductConfigurator
        /// </summary>
        /// <param name="productConfigurator">ProductConfigurator</param>
        public virtual async Task UpdateProductConfiguratorAsync(ProductConfigurator productConfigurator)
        {
            await _productConfiguratorRepository.UpdateAsync(productConfigurator);
        }

        #endregion
    }
}