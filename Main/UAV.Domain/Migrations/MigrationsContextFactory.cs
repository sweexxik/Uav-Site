using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAV.Domain.DbContext;

namespace UAV.Domain.Migrations
{
    public class MigrationsContextFactory : IDbContextFactory<UavDbContext>
    {
        public UavDbContext Create()
        {
            return new UavDbContext("UAV");
        }
    }
}
