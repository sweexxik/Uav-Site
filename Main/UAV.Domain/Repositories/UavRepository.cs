using System.Collections.Generic;
using System.Linq;
using UAV.Domain.DbContext;
using UAV.Domain.Entities;
using UAV.Domain.Interfaces;

namespace UAV.Domain.Repositories
{
    class UavRepository : IUavRepository
    {
        private readonly UavDbContext _db;

        public UavRepository(UavDbContext context)
        {
            _db = context;
        }

        public IEnumerable<Uav> GetAll => _db.Uavs.ToList();

        public Uav Get(int id)
        {
            return _db.Uavs.Find(id);
        }

        public IEnumerable<Payload> GetPayloads(int id)
        {
            return _db.Uavs.Find(id).Payloads;
        }

        public IEnumerable<GcuType> GetGcuTypes(int id)
        {
            return  _db.Uavs.Find(id).GcuTypes;
        }

        public bool Add(Uav uav)
        {
            try
            {
                _db.Uavs.Add(uav);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                _db.Uavs.Remove(_db.Uavs.Find(id));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
