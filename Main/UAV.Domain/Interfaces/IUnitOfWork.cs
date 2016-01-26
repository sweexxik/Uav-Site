using System;
using System.Threading.Tasks;

namespace UAV.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUavRepository Uavs { get; }
        IPayloadRepository Payloads { get; }
        IGcuTypeRepository Gcus { get; }
        IUavTypeRepository UavTypes { get; }
        
        bool Save();
    }
}
