using System.Collections.Generic;
using Main.BLL.DTO;

namespace Main.BLL.Interfaces
{
    public interface IGcuTypeService
    {
        PortableDTO GetPortable();
        MobileDTO GetMobile();
        StationaryDTO GetStationary();
        IEnumerable<GcuTypeDTO> GetAll();
        void Dispose();
    }
}
