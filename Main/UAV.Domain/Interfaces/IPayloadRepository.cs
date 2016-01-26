using System.Collections.Generic;
using UAV.Domain.Entities;

namespace UAV.Domain.Interfaces
{
    public interface IPayloadRepository
    {
        Payload Get(int id);
        IEnumerable<Payload> GetAll { get; }
        IEnumerable<Uav> GetSupportedUavs(int id);
    }
}
