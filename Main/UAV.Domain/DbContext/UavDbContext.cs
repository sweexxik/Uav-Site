using System.Data.Entity;
using UAV.Domain.Entities;

namespace UAV.Domain.DbContext
{
    public class UavDbContext : System.Data.Entity.DbContext
    {
        public UavDbContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<Uav> Uavs { get; set; }
        public DbSet<UavType> UavTypes { get; set; } 
        public DbSet<GcuType> GcuTypes { get; set; }
        public DbSet<Portable> PortableSet { get; set; }
        public DbSet<Mobile> MobileSet { get; set; }
        public DbSet<Stationary> StationatySet { get; set; }
        public DbSet<Payload> Payloads { get; set; }
        public DbSet<TV> TvSet { get; set; }
        public DbSet<IR> IrSet { get; set; }
        public DbSet<Frontal> FrontalSet { get; set; }
        public DbSet<Photo> PhotoSet { get; set; }
        public DbSet<Multispectral> MultispectralSet { get; set; }

    }
}
