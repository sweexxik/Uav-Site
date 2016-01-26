using System.Collections.Generic;
using Main.BLL.DTO;

namespace Main.BLL.Interfaces
{
    public interface IPayloadService
    {
        TVDTO GetTV();
        IRDTO GetIR();
        FrontalDTO GetFrontal();
        OtusDTO GetOtus();
        MultispectralDTO GetMultispectral();
        PhotoDTO GetPhoto();
        IEnumerable<PayloadDTO> GetAll();
        void Dispose();
    }
}
