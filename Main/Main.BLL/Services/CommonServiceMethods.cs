using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Main.BLL.DTO;
using UAV.Domain.Entities;
using UAV.Domain.Interfaces;

namespace Main.BLL.Services
{
    /// <summary>
    /// Методы, используещиеся всеми сервисами уровня BLL:
    /// 1. Mapper-ы сущностей
    /// 2. Получение набора данных из БД
    /// </summary>
    public class CommonServiceMethods
    {
        private readonly IUnitOfWork _db;
       
        public CommonServiceMethods(IUnitOfWork contextOfWork)
        {
            _db = contextOfWork;
        }

        //---------------uav mappers---------------------------------------------------------------
        protected UavDTO ToUavDTO(Uav uav)
        {
            Mapper.Reset();
            Mapper.CreateMap<Uav, UavDTO>()
                  .ForMember("Type", x => x.UseValue(ToUavTypeDTO(uav.Type)))
                  .ForMember("Payloads", x => x.UseValue(PayloadsFromUav(uav.Id)))
                  .ForMember("GcuTypes", x => x.UseValue(GcuTypesFromUav(uav.Id)));

            return Mapper.Map<Uav, UavDTO>(uav);
        }

        protected GcuTypeDTO ToGcuTypeDTO(GcuType gcu)
        {
            Mapper.CreateMap<GcuType, GcuTypeDTO>().ForMember("SupportedUavs", x => x.UseValue(UavTypesFromGcu(gcu.Id)));
            return Mapper.Map<GcuType, GcuTypeDTO>(gcu);
        }

        protected PayloadDTO ToPayloadDTO(Payload pld)
        {
            Mapper.CreateMap<Payload, PayloadDTO>().ForMember("SupportedUavs", x => x.UseValue(UavTypesFromPayloads(pld.Id)));
            return Mapper.Map<Payload, PayloadDTO>(pld);
        }

        protected UavTypeDTO ToUavTypeDTO(UavType type)
        {
            Mapper.CreateMap<UavType, UavTypeDTO>();
            return Mapper.Map<UavType, UavTypeDTO>(type);
        }
       
        //---------------payload mappers---------------------------------------------------------------
        protected TVDTO TV()
        {
            Mapper.CreateMap<TV, TVDTO>().ForMember("SupportedUavs", x => x.UseValue(UavTypesFromPayloads(2)));
            return Mapper.Map<TV, TVDTO>(_db.Payloads.Get(2) as TV);
        }

        protected IRDTO IR()
        {
            Mapper.CreateMap<IR, IRDTO>().ForMember("SupportedUavs", x => x.UseValue(UavTypesFromPayloads(3)));
            return Mapper.Map<IR, IRDTO>(_db.Payloads.Get(3) as IR);
        }

        protected FrontalDTO Frontal()
        {
            Mapper.CreateMap<Frontal, FrontalDTO>().ForMember("SupportedUavs", x => x.UseValue(UavTypesFromPayloads(4)));
            return Mapper.Map<Frontal, FrontalDTO>(_db.Payloads.Get(4) as Frontal);
        }

        protected OtusDTO Otus()
        {
            Mapper.CreateMap<Otus, OtusDTO>().ForMember("SupportedUavs", x => x.UseValue(UavTypesFromPayloads(10)));
            return Mapper.Map<Otus, OtusDTO>(_db.Payloads.Get(10) as Otus);
        }

        protected MultispectralDTO Multispectral()
        {
            Mapper.CreateMap<Multispectral, MultispectralDTO>().ForMember("SupportedUavs", x => x.UseValue(UavTypesFromPayloads(5)));
            return Mapper.Map<Multispectral, MultispectralDTO>(_db.Payloads.Get(5) as Multispectral);

        }

        protected PhotoDTO Photo()
        {
            Mapper.CreateMap<Photo, PhotoDTO>().ForMember("SupportedUavs", x => x.UseValue(UavTypesFromPayloads(1)));
            return Mapper.Map<Photo, PhotoDTO>(_db.Payloads.Get(1) as Photo);
        }

       //---------------gcu mappers---------------------------------------------------------------
        protected PortableDTO Portable()
        {
            Mapper.CreateMap<Portable, PortableDTO>().ForMember("SupportedUavs", x => x.UseValue(UavTypesFromGcu(1)));
            return Mapper.Map<Portable, PortableDTO>(_db.Gcus.Get(1) as Portable);
        }

        protected MobileDTO Mobile()
        {
            Mapper.CreateMap<Mobile, MobileDTO>().ForMember("SupportedUavs", x => x.UseValue(UavTypesFromGcu(2)));
            return Mapper.Map<Mobile, MobileDTO>(_db.Gcus.Get(2) as Mobile);
        }

        protected StationaryDTO Stationary()
        {
            Mapper.CreateMap<Stationary, StationaryDTO>().ForMember("SupportedUavs", x => x.UseValue(UavTypesFromGcu(3)));
            return Mapper.Map<Stationary, StationaryDTO>(_db.Gcus.Get(3) as Stationary);
        }

        //---------------get entities from ----------------------------------------------------
        protected IEnumerable<UavTypeDTO> UavTypesFromGcu(int id)
        {
            return _db.Gcus.GetSupportedUavs(id).Select(item => ToUavTypeDTO(item.Type)).ToList();
        }

        protected IEnumerable<UavTypeDTO> UavTypesFromPayloads(int id)
        {
            return _db.Payloads.GetSupportedUavs(id).Select(item => ToUavTypeDTO(item.Type)).ToList();
        }

        protected IEnumerable<PayloadDTO> PayloadsFromUav(int id)
        {
            return _db.Uavs.GetPayloads(id).Select(ToPayloadDTO).ToList();
        }

        protected IEnumerable<GcuTypeDTO> GcuTypesFromUav(int id)
        {
            return _db.Uavs.GetGcuTypes(id).Select(ToGcuTypeDTO).ToList();
        }
        
        //---------------public--------------------------------------------------------------------
        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
