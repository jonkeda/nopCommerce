using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;

namespace Nop.Data.Mapping.Builders.Catalog
{
    /// <summary>
    /// Represents a product configurator entity builder
    /// </summary>
    public partial class ProductConfiguratorBuilder : NopEntityBuilder<ProductConfigurator>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(ProductConfigurator.Name)).AsString(400).NotNullable()
                .WithColumn(nameof(ProductConfigurator.MetaKeywords)).AsString(400).Nullable()
                .WithColumn(nameof(ProductConfigurator.MetaTitle)).AsString(400).Nullable()
                // PCFG
                .WithColumn(nameof(ProductConfigurator.FullClassName)).AsString(400).Nullable()
                .WithColumn(nameof(ProductConfigurator.RouteName)).AsString(400).Nullable()
                .WithColumn(nameof(ProductConfigurator.Definition)).AsString(int.MaxValue).NotNullable()
                .WithColumn(nameof(ProductConfigurator.Attributes)).AsString(int.MaxValue).NotNullable();
        }

        #endregion
    }

    /// <summary>
    /// Represents a product entity builder
    /// </summary>
    public partial class ProductBuilder : NopEntityBuilder<Product>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(Product.Name)).AsString(400).NotNullable()
                .WithColumn(nameof(Product.MetaKeywords)).AsString(400).Nullable()
                .WithColumn(nameof(Product.MetaTitle)).AsString(400).Nullable()
                .WithColumn(nameof(Product.Sku)).AsString(400).Nullable()
                .WithColumn(nameof(Product.ManufacturerPartNumber)).AsString(400).Nullable()
                .WithColumn(nameof(Product.Gtin)).AsString(400).Nullable()
                .WithColumn(nameof(Product.RequiredProductIds)).AsString(1000).Nullable()
                .WithColumn(nameof(Product.AllowedQuantities)).AsString(1000).Nullable()
                // PCFG
                .WithColumn(nameof(Product.Configuration)).AsString(int.MaxValue).NotNullable();
        }

        #endregion
    }
}