using FluentMigrator;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Orders;
using Nop.Data.Mapping;

namespace Nop.Data.Migrations.UpgradeTo441
{
    /// <summary>
    /// Migrate tables for ProductConfigurator
    /// PCFG
    /// </summary>
    [NopMigration("2021/03/10 12:00:00:9037680", "ProductConfigurator")]
    [SkipMigrationOnInstall]
    public class ProductConfiguratorMigration : MigrationBase
    {
        #region Fields

        private readonly IMigrationManager _migrationManager;

        #endregion

        #region Ctor

        public ProductConfiguratorMigration(IMigrationManager migrationManager)
        {
            _migrationManager = migrationManager;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Collect the UP migration expressions
        /// </summary>
        public override void Up()
        {
            if (!Schema.Table(NameCompatibilityManager.GetTableName(typeof(ProductConfigurator))).Exists())
                _migrationManager.BuildTable<ProductConfigurator>(Create);

            if (!Schema.Table(NameCompatibilityManager.GetTableName(typeof(Product)))
                .Column(nameof(Product.ConfiguratorId)).Exists())
            {
                //add new columns
                Alter.Table(NameCompatibilityManager.GetTableName(typeof(Product)))
                    .AddColumn(nameof(Product.IsConfiguratorEnabled)).AsBoolean().WithDefaultValue(false);
                Alter.Table(NameCompatibilityManager.GetTableName(typeof(Product)))
                    .AddColumn(nameof(Product.ConfiguratorId)).AsInt32();
                Alter.Table(NameCompatibilityManager.GetTableName(typeof(Product)))
                    .AddColumn(nameof(Product.Configuration)).AsString(int.MaxValue).Nullable();
                Alter.Table(NameCompatibilityManager.GetTableName(typeof(Product)))
                    .AddColumn(nameof(Product.ConfigurationDescription)).AsString(int.MaxValue).Nullable();
                Alter.Table(NameCompatibilityManager.GetTableName(typeof(Product)))
                    .AddColumn(nameof(Product.ConfigurationPictureId)).AsInt32();
            }

            if (!Schema.Table(NameCompatibilityManager.GetTableName(typeof(OrderItem)))
                .Column(nameof(OrderItem.Configuration)).Exists())
            {
                //add new columns
                Alter.Table(NameCompatibilityManager.GetTableName(typeof(OrderItem)))
                    .AddColumn(nameof(OrderItem.Configuration)).AsString(int.MaxValue).Nullable();
                Alter.Table(NameCompatibilityManager.GetTableName(typeof(OrderItem)))
                    .AddColumn(nameof(OrderItem.ConfigurationDescription)).AsString(int.MaxValue).Nullable();
                Alter.Table(NameCompatibilityManager.GetTableName(typeof(OrderItem)))
                    .AddColumn(nameof(OrderItem.ConfigurationPictureId)).AsInt32();
                Alter.Table(NameCompatibilityManager.GetTableName(typeof(ShoppingCartItem)))
                    .AddColumn(nameof(ShoppingCartItem.ConfigurationPrice)).AsDecimal(18, 4).Nullable();
            }

            if (!Schema.Table(NameCompatibilityManager.GetTableName(typeof(ShoppingCartItem)))
                .Column(nameof(ShoppingCartItem.Configuration)).Exists())
            {
                //add new columns
                Alter.Table(NameCompatibilityManager.GetTableName(typeof(ShoppingCartItem)))
                    .AddColumn(nameof(ShoppingCartItem.Configuration)).AsString(int.MaxValue).Nullable();
                Alter.Table(NameCompatibilityManager.GetTableName(typeof(ShoppingCartItem)))
                    .AddColumn(nameof(ShoppingCartItem.ConfigurationDescription)).AsString(int.MaxValue).Nullable();
                Alter.Table(NameCompatibilityManager.GetTableName(typeof(ShoppingCartItem)))
                    .AddColumn(nameof(ShoppingCartItem.ConfigurationPictureId)).AsInt32();
                Alter.Table(NameCompatibilityManager.GetTableName(typeof(ShoppingCartItem)))
                    .AddColumn(nameof(ShoppingCartItem.ConfigurationPrice)).AsDecimal(18, 4).Nullable();
            }
        }

        public override void Down()
        {
            //add the downgrade logic if necessary 
        }

        #endregion
    }
}
