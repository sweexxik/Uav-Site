using System.Collections.Generic;
using System.Linq;
using UAV.Domain.DbContext;
using UAV.Domain.Entities;
using UAV.Domain.Interfaces;

namespace UAV.Domain.Repositories
{
    class PayloadRepository : IPayloadRepository
    {
        private readonly UavDbContext _db;

        public PayloadRepository(UavDbContext context)
        {
            _db = context;
        }
        public IEnumerable<Payload> GetAll => _db.Payloads.ToList();

        public Payload Get(int id)
        {
            return _db.Payloads.Find(id);
        }

        public IEnumerable<Uav> GetSupportedUavs(int id)
        {
            return _db.Payloads.Find(id).SupportedUavs;
        }
    }
}

