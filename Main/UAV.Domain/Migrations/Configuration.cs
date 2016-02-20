using System.Data.Entity.Migrations.Infrastructure;

namespace UAV.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UAV.Domain.DbContext.UavDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "UAV.Domain.DbContext.UavDbContext";
        }

        protected override void Seed(UAV.Domain.DbContext.UavDbContext context)
        {
            
        }
    }
}
