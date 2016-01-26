using System.Collections.Generic;
using AutoMapper;
using Main.BLL.DTO;
using Main.BLL.Interfaces;
using UAV.Domain.Entities;
using UAV.Domain.Interfaces;

namespace Main.BLL.Services
{
    /// <summary>
    ///  Сервис выполняет функции передачи на уровень представления данных о конкретном типе, наследуемом от Payload
    /// </summary>
    public class PayloadService : CommonServiceMethods, IPayloadService
    {
        private readonly IUnitOfWork _db;

        public PayloadService(IUnitOfWork contextOfWork) : base(contextOfWork)
        {
            _db = contextOfWork;
        }

        public TVDTO GetTV()
        {
            return TV();
        }

        public IRDTO GetIR()
        {
            return IR();
        }

        public FrontalDTO GetFrontal()
        {
            return Frontal();
        }

        public OtusDTO GetOtus()
        {
            return Otus();
        }

        public MultispectralDTO GetMultispectral()
        {
           return Multispectral();
        }

        public PhotoDTO GetPhoto()
        {
            return Photo();
        }

        public IEnumerable<PayloadDTO> GetAll()
        {
            var plds = _db.Payloads.GetAll;
            var model = new List<PayloadDTO>();

            foreach (var item in plds)
            {
                Mapper.CreateMap<Payload, PayloadDTO>().ForMember("SupportedUavs", x => x.UseValue(UavTypesFromPayloads(item.Id)));
                model.Add(Mapper.Map<Payload, PayloadDTO>(item));
            }
           
            return model;
        }

    }
}
