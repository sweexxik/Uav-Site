using System.Collections.Generic;
using AutoMapper;
using Main.BLL.DTO;
using Main.BLL.Interfaces;
using UAV.Domain.Entities;
using UAV.Domain.Interfaces;

namespace Main.BLL.Services
{
    /// <summary>
    /// Сервис выполняет функции передачи на уровень представления данных о конкретном типе, наследуемом от GcuType
    /// </summary>
    public class GcuTypeService : CommonServiceMethods, IGcuTypeService
    {
        private readonly IUnitOfWork _db;

        public GcuTypeService(IUnitOfWork context): base(context)
        {
            _db = context;
        }

        public PortableDTO GetPortable()
        {
            return Portable();
        }

        public MobileDTO GetMobile()
        {
            return Mobile();
        }

        public StationaryDTO GetStationary()
        {
          return Stationary();
        }

        public IEnumerable<GcuTypeDTO> GetAll()
        {
            var gcus = _db.Gcus.GetAll;
            var model = new List<GcuTypeDTO>();

            foreach (var item in gcus)
            {
                Mapper.CreateMap<GcuType, GcuTypeDTO>().ForMember("SupportedUavs", x => x.UseValue(UavTypesFromGcu(item.Id)));
                model.Add(Mapper.Map<GcuType, GcuTypeDTO>(item));
            }

            return model;
        }
        
    }
}
