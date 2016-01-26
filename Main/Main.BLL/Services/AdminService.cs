using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using Main.BLL.DTO;
using Main.BLL.Interfaces;
using Main.BLL.Models;
using UAV.Domain.Entities;
using UAV.Domain.Interfaces;

namespace Main.BLL.Services
{
    /// <summary>
    /// Сервис выполняет функции:
    /// 1. Mapper-a ( Uav => UavDTO, etc)
    /// 2. Передает на уровень представления необходимые данные, полученные из БД, через IUnitOfWork
    /// </summary>
    public class AdminService : CommonServiceMethods, IAdminService
    {
        private readonly IUnitOfWork _db;

        public AdminService(IUnitOfWork context) : base(context)
        {
            _db = context;
            Mapper.Reset();
        }

        public IEnumerable<UavDTO> Uavs => _db.Uavs.GetAll.Select(ToUavDTO).ToList();
        public IEnumerable<PayloadDTO> Payoads => _db.Payloads.GetAll.Select(ToPayloadDTO).ToList();
        public IEnumerable<GcuTypeDTO> Gcus => _db.Gcus.GetAll.Select(ToGcuTypeDTO).ToList();
        public IEnumerable<UavTypeDTO> UavTypes => _db.UavTypes.GetAll.Select(ToUavTypeDTO).ToList();

        public UavDTO GetUav(int id)
        {
            return _db.Uavs.Get(id) != null ? ToUavDTO(_db.Uavs.Get(id)) : new UavDTO();
        }

        public UavTypeDTO GetUavType(int id) => ToUavTypeDTO(_db.UavTypes.Get(id));

        public PayloadDTO GetPayload(int id)
        {
            switch (id)
            {
                case 1:
                    return Photo();
                case 2:
                    return TV();
                case 3:
                    return IR();
                case 4:
                    return Frontal();
                case 5:
                    return Multispectral();
                case 10:
                    return Otus();
                default: return new PayloadDTO();
            }
        }

        public GcuTypeDTO GetGcu(int id)
        {
            switch (id)
            {
                case 1:
                    return Portable();
                case 2:
                    return Mobile();
                case 3:
                    return Stationary();
                default:
                    return new GcuTypeDTO();
            }
        }

        public UavEditModel EditUav(int id)
        {
            return new UavEditModel()
            {
                Uav = GetUav(id) ?? new UavDTO(),
                GcuTypes = Gcus,
                Payloads = Payoads,
                UavTypes = UavTypes
            };
        }

        public PayloadEditModel EditPayload(int id)
        {
            return new PayloadEditModel()
            {
                Payload = GetPayload(id) ?? new PayloadDTO(),
                UavTypes = UavTypes
            };
        }

        public GcuEditModel EditGcu(int id)
        {
            return new GcuEditModel()
            {
                GcuType = GetGcu(id) ?? new GcuTypeDTO(),
                UavTypes = UavTypes
            };
        }

        public bool SaveUav(UavEditModel model)
        {
            if (model.Uav == null || model.Payloads == null || model.GcuTypes == null)
                return false;

            var uav = (model.Uav.Id != 0) ? _db.Uavs.Get(model.Uav.Id) : new Uav();

            uav.Endurance = model.Uav.Endurance;
            uav.FlightRadius = model.Uav.FlightRadius;
            uav.LandingProcedure = model.Uav.LandingProcedure;
            uav.Length = model.Uav.Length;
            uav.MaxSpeed = model.Uav.MaxSpeed;
            uav.MinSpeed = model.Uav.MinSpeed;
            uav.PowerUnit = model.Uav.PowerUnit;
            uav.ServiceCeiling = model.Uav.ServiceCeiling;
            uav.TakeoffProcedure = model.Uav.TakeoffProcedure;
            uav.Wingspan = model.Uav.Wingspan;
            uav.TakeoffWeight = model.Uav.TakeoffWeight;

            uav.Payloads?.Clear();
            uav.GcuTypes?.Clear();

            if (uav.GcuTypes == null)
                uav.GcuTypes = new List<GcuType>();

            if (uav.Payloads == null)
                uav.Payloads = new List<Payload>();

            foreach (var item in model.Payloads)
                uav.Payloads.Add(_db.Payloads.GetAll.First(x => x.Id == item.Id));

            foreach (var item in model.GcuTypes)
                uav.GcuTypes.Add(_db.Gcus.GetAll.First(x => x.Id == item.Id));

            uav.Type = _db.UavTypes.GetAll.First(x => x.Id == model.Uav.Type.Id);

            if (model.Uav.Id == 0)
                return _db.Uavs.Add(uav) && _db.Save();

            return _db.Save();
        }

        public bool SavePayload(PayloadEditModel model)
        {
            if (model.Payload == null || model.UavTypes == null)
                return false;

            var temp = (model.Payload.Id != 0) ? _db.Payloads.Get(model.Payload.Id) : new Payload();

            switch (model.Payload.Id)
            {
                case 1:
                    {
                        #region Photo
                        var cam = temp as Photo;
                        var camDto = model.Payload as PhotoDTO;

                        cam.ImageFormat = camDto.ImageFormat;
                        cam.Lens = camDto.Lens;
                        cam.PictureElements = camDto.PictureElements;
                        cam.PitchRotation = camDto.PitchRotation;
                        cam.RollingRig = camDto.RollingRig;
                        cam.Stabilization = camDto.Stabilization;
                        cam.WatchingCamera = camDto.WatchingCamera;
                        cam.Weight = camDto.Weight;

                        cam.SupportedUavs.Clear();

                        foreach (var item in model.UavTypes)
                            cam.SupportedUavs.Add(_db.Uavs.GetAll.First(x => x.Id == item.Id));
                    }
                    break;
                    #endregion

                case 2:
                    {
                        #region TV
                        var cam = temp as TV;
                        var camDto = model.Payload as TVDTO;

                        cam.EffectivePictureElements = camDto.EffectivePictureElements;
                        cam.Gimbal = camDto.Gimbal;
                        cam.LinearResolution = camDto.LinearResolution;
                        cam.PitchRotation = camDto.PitchRotation;
                        cam.RollingRig = camDto.RollingRig;
                        cam.Stabilization = camDto.Stabilization;
                        cam.Zoom = camDto.Zoom;
                        cam.Weight = camDto.Weight;

                        cam.SupportedUavs.Clear();

                        foreach (var item in model.UavTypes)
                            cam.SupportedUavs.Add(_db.Uavs.GetAll.First(x => x.Id == item.Id));
                    }
                    break;
                    #endregion

                case 3:
                    {
                        #region IR
                        var cam = temp as IR;
                        var camDto = model.Payload as IRDTO;

                        cam.DispalyFormat = cam.DispalyFormat;
                        cam.Lens = camDto.Lens;
                        cam.Gimbal = camDto.Gimbal;
                        cam.FullFrameRates = camDto.FullFrameRates;
                        cam.PitchRotation = camDto.PitchRotation;
                        cam.RollingRig = camDto.RollingRig;
                        cam.Stabilization = camDto.Stabilization;
                        cam.WatchingCamera = camDto.WatchingCamera;
                        cam.Weight = camDto.Weight;
                        cam.HorizontalResolution = camDto.HorizontalResolution;
                        cam.LinearResolution = camDto.LinearResolution;
                        cam.SpectralBand = camDto.SpectralBand;

                        cam.SupportedUavs.Clear();

                        foreach (var item in model.UavTypes)
                            cam.SupportedUavs.Add(_db.Uavs.GetAll.First(x => x.Id == item.Id));
                    }
                    break;
                    #endregion

                case 4:
                    {
                        #region Frontal
                        var cam = temp as Frontal;
                        var camDto = model.Payload as FrontalDTO;

                        cam.AngleOfView = camDto.AngleOfView;
                        cam.Lens = camDto.Lens;
                        cam.Definition = camDto.Definition;
                        cam.SpectralBand = camDto.SpectralBand;
                        cam.Weight = camDto.Weight;

                        cam.SupportedUavs.Clear();

                        foreach (var item in model.UavTypes)
                            cam.SupportedUavs.Add(_db.Uavs.GetAll.First(x => x.Id == item.Id));
                    }
                    break;
                    #endregion

                case 5:
                    {
                        #region MS
                        var cam = temp as Multispectral;
                        var camDto = model.Payload as MultispectralDTO;

                        cam.CameraCoverage = camDto.CameraCoverage;
                        cam.Dimensions = camDto.Dimensions;
                        cam.ImageResolution = camDto.ImageResolution;
                        cam.MeasurementRange = camDto.MeasurementRange;
                        cam.RateOfFrameRecording = camDto.RateOfFrameRecording;
                        cam.ResolutionOfCourseCamera = camDto.ResolutionOfCourseCamera;
                        cam.Weight = camDto.Weight;

                        cam.SupportedUavs.Clear();

                        foreach (var item in model.UavTypes)
                            cam.SupportedUavs.Add(_db.Uavs.GetAll.First(x => x.Id == item.Id));
                    }
                    break;
                    #endregion

                case 10:
                    {
                        #region Otus
                        var cam = temp as Otus;
                        var camDto= model.Payload as OtusDTO;

                        cam.Feedback = camDto.Feedback;
                        cam.GimbalSystem = camDto.GimbalSystem;
                        cam.PanTilRange = camDto.PanTilRange;
                        cam.Interfaces = camDto.Interfaces;
                        cam.RangeFinder = camDto.RangeFinder;
                        cam.Stabiliz = camDto.Stabiliz;
                        cam.Temperature = camDto.Temperature;
                        cam.Weight = camDto.Weight;

                        cam.SupportedUavs.Clear();

                        foreach (var item in model.UavTypes)
                            cam.SupportedUavs.Add(_db.Uavs.GetAll.First(x => x.Id == item.Id));
                    }
                    break;
                #endregion
                default:
                    return false;
            }

            return _db.Save();
        }

        public bool SaveGcu(GcuEditModel model)
        {
            if (model.GcuType == null || model.UavTypes == null)
                return false;

            var temp = _db.Gcus.Get(model.GcuType.Id);

            switch (temp.Id)
            {
                case 1:
                    {
                        #region Portable
                        var gcu = temp as Portable;
                        var gcuDto = model.GcuType as PortableDTO;
                        gcu.DeployTime = gcuDto.DeployTime;
                        gcu.Name = gcuDto.Name;
                        gcu.Size = gcuDto.Size;
                        gcu.Places = gcuDto.Places;
                        gcu.SupportedUavs.Clear();

                        foreach (var item in model.UavTypes)
                            gcu.SupportedUavs.Add(_db.Uavs.GetAll.First(x => x.Id == item.Id));

                    }
                    break;
                #endregion
                case 2:
                    {
                        #region Mobile
                        var gcu = temp as Mobile;
                        var gcuDto = model.GcuType as MobileDTO;

                        gcu.CarType = gcuDto.CarType;
                        gcu.Name = gcuDto.Name;
                        gcu.Size = gcuDto.Size;
                        gcu.Places = gcuDto.Places;

                        gcu.SupportedUavs.Clear();

                        foreach (var item in model.UavTypes)
                            gcu.SupportedUavs.Add(_db.Uavs.GetAll.First(x => x.Id == item.Id));
                    }
                    break;
                    #endregion
                case 3:
                    {
                        #region Stationary
                        var gcu = temp as Stationary;
                        var gcuDto = model.GcuType as StationaryDTO;

                        gcu.DeployPlaces = gcuDto.DeployPlaces;
                        gcu.Name = gcuDto.Name;
                        gcu.Size = gcuDto.Size;
                        gcu.Places = gcuDto.Places;

                        gcu.SupportedUavs.Clear();

                        foreach (var item in model.UavTypes)
                            gcu.SupportedUavs.Add(_db.Uavs.GetAll.First(x => x.Id == item.Id));
                    }
                    break;
#endregion
                default:
                    return false;
            }
            return _db.Save();
        }

        public bool SaveUavType(UavTypeDTO model)
        {
            if (model == null)
                return false;

            var type = model.Id != 0 ? _db.UavTypes.Get(model.Id) : new UavType();

            type.Name = model.Name;

            if (model.Id == 0)
                return _db.UavTypes.Add(type) && _db.Save();

            return _db.Save();
        }

        public bool DeleteUav(int id)
        {
            return _db.Uavs.Delete(id) && _db.Save();
        }

        public bool DeleteUavType(int id)
        {
            return  _db.UavTypes.Delete(id) && _db.Save();
        }
        
    }
}
