using FluentMigrator;
using Nop.Core.Domain.Catalog;
using Nop.Data.Mapping;

namespace Nop.Data.Migrations.UpgradeTo441
{
    /// <summary>
    /// Migrate tables for ProductConfigurator ProductId
    /// PCFG
    /// </summary>
    [NopMigration("2021/04/10 12:00:00:9037680", "ProductConfigurator")]
    [SkipMigrationOnInstall]
    public class ProductConfiguratorProductIdMigration : MigrationBase
    {
        #region Fields

        private readonly IMigrationManager _migrationManager;

        #endregion

        #region Ctor

        public ProductConfiguratorProductIdMigration(IMigrationManager migrationManager)
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
            if (!Schema.Table(NameCompatibilityManager.GetTableName(typeof(ProductConfigurator)))
                .Column(nameof(ProductConfigurator.ProductId)).Exists())
            {
                //add new columns
                Alter.Table(NameCompatibilityManager.GetTableName(typeof(ProductConfigurator)))
                    .AddColumn(nameof(ProductConfigurator.ProductId)).AsInt32().WithDefaultValue(0);
            }

        }

        public override void Down()
        {
            //add the downgrade logic if necessary 
        }

        #endregion
    }
}
