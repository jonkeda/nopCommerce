using FluentMigrator;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Media;
using Nop.Core.Domain.Orders;
using Nop.Data.Mapping;

namespace Nop.Data.Migrations.UpgradeTo441
{
    /// <summary>
    /// Migrate tables for new media types
    /// NEWMEDIA
    /// </summary>
    [NopMigration("2021/03/26 12:00:00:9037680", "NewMedia")]
    [SkipMigrationOnInstall]
    public class NewMediaMigrationMigration : MigrationBase
    {
        #region Fields

        private readonly IMigrationManager _migrationManager;

        #endregion

        #region Ctor

        public NewMediaMigrationMigration(IMigrationManager migrationManager)
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
            if (!Schema.Table(NameCompatibilityManager.GetTableName(typeof(Picture)))
                .Column(nameof(Picture.MediaTypeId)).Exists())
            {
                //add new columns
                Alter.Table(NameCompatibilityManager.GetTableName(typeof(Picture)))
                    .AddColumn(nameof(Picture.MediaTypeId)).AsInt32().WithDefaultValue(0);
            }
            if (!Schema.Table(NameCompatibilityManager.GetTableName(typeof(Picture)))
                .Column(nameof(Picture.Name)).Exists())
            {
                //add new columns
                Alter.Table(NameCompatibilityManager.GetTableName(typeof(Picture)))
                    .AddColumn(nameof(Picture.Name)).AsString(300).Nullable();
            }
        }

        public override void Down()
        {
            //add the downgrade logic if necessary 
        }

        #endregion
    }
}
