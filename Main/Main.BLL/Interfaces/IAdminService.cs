using System.Collections.Generic;
using System.Threading.Tasks;
using Main.BLL.DTO;
using Main.BLL.Models;


namespace Main.BLL.Interfaces
{
    public interface IAdminService
    {
        IEnumerable<UavDTO> Uavs { get; }
        IEnumerable<PayloadDTO> Payoads { get; }
        IEnumerable<GcuTypeDTO> Gcus { get; }
        IEnumerable<UavTypeDTO> UavTypes { get; }

        UavDTO GetUav(int id);
        PayloadDTO GetPayload(int id);
        GcuTypeDTO GetGcu(int id);
        UavTypeDTO GetUavType(int id);

        UavEditModel EditUav(int id);
        PayloadEditModel EditPayload(int id);
        GcuEditModel EditGcu(int id);

        bool SaveUav(UavEditModel model);
        bool SavePayload(PayloadEditModel model);
        bool SaveGcu(GcuEditModel model);
        bool SaveUavType(UavTypeDTO model);
        bool DeleteUav(int id);
        bool DeleteUavType(int id);








    }
}
