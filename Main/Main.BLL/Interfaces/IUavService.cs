using System.Collections.Generic;
using Main.BLL.DTO;

namespace Main.BLL.Interfaces
{
    public interface IUavService
    {
        UavDTO GetUav(int id);
        IEnumerable<UavDTO> GetAll { get; }
        IEnumerable<GcuTypeDTO> GetGcuTypes(int id);
        IEnumerable<PayloadDTO> GetPayloads(int id);
        void Dispose();
    }
}
