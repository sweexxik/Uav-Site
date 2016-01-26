using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Main.BLL.DTO;
using Main.BLL.Interfaces;
using UAV.Domain.Interfaces;

namespace Main.BLL.Services
{
    /// <summary>
    ///  Сервис выполняет функции передачи на уровень представления данных о uav сущности
    /// </summary>
    public class UavService : CommonServiceMethods, IUavService
    {
        private readonly IUnitOfWork _db;

        public UavService(IUnitOfWork contextOfWork) : base(contextOfWork)
        {
            _db = contextOfWork;
            Mapper.Reset();
        }
        
        public UavDTO GetUav(int id)
        {
           return ToUavDTO(_db.Uavs.Get(id));
        }

        public IEnumerable<UavDTO> GetAll => _db.Uavs.GetAll.Select(ToUavDTO).ToList();

        public  IEnumerable<GcuTypeDTO> GetGcuTypes(int id)
        {
            return _db.Uavs.GetGcuTypes(id).Select(ToGcuTypeDTO).ToList();
        }

        public  IEnumerable<PayloadDTO> GetPayloads(int id)
        {
            return _db.Uavs.GetPayloads(id).Select(ToPayloadDTO).ToList();
        }
    }
}
