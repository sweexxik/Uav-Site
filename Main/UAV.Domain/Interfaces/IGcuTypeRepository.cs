using System.Collections.Generic;
using UAV.Domain.Entities;

namespace UAV.Domain.Interfaces
{
    public interface IGcuTypeRepository
    {
        GcuType Get(int id);
        IEnumerable<GcuType> GetAll { get; }
        IEnumerable<Uav> GetSupportedUavs(int id);
    }
}
