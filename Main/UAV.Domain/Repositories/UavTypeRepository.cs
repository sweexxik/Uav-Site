using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UAV.Domain.DbContext;
using UAV.Domain.Entities;
using UAV.Domain.Interfaces;

namespace UAV.Domain.Repositories
{
    class UavTypeRepository : IUavTypeRepository
    {
        private readonly UavDbContext _db;

        public UavTypeRepository(UavDbContext context)
        {
            _db = context;
        }

        public IEnumerable<UavType> GetAll => _db.UavTypes.ToList();

        public UavType Get(int id)
        {
            return _db.UavTypes.Find(id);
        }

        public bool Add(UavType type)
        {
            try
            {
                _db.UavTypes.Add(type);
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
                _db.UavTypes.Remove(_db.UavTypes.Find(id));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
