using System.Collections.Generic;
using System.Linq;
using UAV.Domain.DbContext;
using UAV.Domain.Entities;
using UAV.Domain.Interfaces;

namespace UAV.Domain.Repositories
{
    class GcuTypeRepository : IGcuTypeRepository
    {
        private readonly UavDbContext _db;

        public GcuTypeRepository(UavDbContext context)
        {
            _db = context;
        }

        public IEnumerable<GcuType> GetAll => _db.GcuTypes.ToList();

        public GcuType Get(int id)
        {
            return _db.GcuTypes.Find(id);
        }
        
        public IEnumerable<Uav> GetSupportedUavs(int id)
        {
            return _db.GcuTypes.Find(id).SupportedUavs;
        }
        
    }
}
