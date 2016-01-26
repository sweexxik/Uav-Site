using System.Collections.Generic;
using UAV.Domain.Entities;

namespace UAV.Domain.Interfaces
{
    public interface IUavRepository
    {
        IEnumerable<Uav> GetAll { get; }
        Uav Get(int id);
        IEnumerable<Payload> GetPayloads(int id);
        IEnumerable<GcuType> GetGcuTypes(int id);
        bool Add(Uav uav);
        bool Delete(int id);
    }
}
