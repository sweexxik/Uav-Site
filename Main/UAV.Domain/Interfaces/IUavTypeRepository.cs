using System.Collections.Generic;
using System.Threading.Tasks;
using UAV.Domain.Entities;

namespace UAV.Domain.Interfaces
{
    public interface IUavTypeRepository
    {
        IEnumerable<UavType> GetAll { get; }
        UavType Get(int id);
        bool Add(UavType type);
        bool Delete(int id);
    }
}
