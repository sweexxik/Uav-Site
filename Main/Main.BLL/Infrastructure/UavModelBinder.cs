using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Main.BLL.DTO;
using Main.BLL.Models;


namespace Main.BLL.Infrastructure
{
    /// <summary>
    /// Связыватель модели UavEditModel для Edit метода Admin контроллера
    /// </summary>
    public class UavModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueProvider = bindingContext.ValueProvider;
            var model = new UavEditModel();

            try
            {
                model.Uav = new UavDTO()
                {
                    Type = new UavTypeDTO() { Id = int.Parse((string)valueProvider.GetValue("UavType").ConvertTo(typeof(string))) },
                    Id = (int)valueProvider.GetValue("Uav.Id").ConvertTo(typeof(int)),
                    FlightRadius = (int)valueProvider.GetValue("Uav.FlightRadius").ConvertTo(typeof(int)),
                    Endurance = (string)valueProvider.GetValue("Uav.Endurance").ConvertTo(typeof(string)),
                    MaxSpeed = (int)valueProvider.GetValue("Uav.MaxSpeed").ConvertTo(typeof(int)),
                    MinSpeed = (int)valueProvider.GetValue("Uav.MinSpeed").ConvertTo(typeof(int)),
                    TakeoffWeight = (int)valueProvider.GetValue("Uav.TakeoffWeight").ConvertTo(typeof(int)),
                    Length = (int)valueProvider.GetValue("Uav.Length").ConvertTo(typeof(int)),
                    TakeoffProcedure = (string)valueProvider.GetValue("Uav.TakeoffProcedure").ConvertTo(typeof(string)),
                    LandingProcedure = (string)valueProvider.GetValue("Uav.LandingProcedure").ConvertTo(typeof(string)),
                    ServiceCeiling = (int)valueProvider.GetValue("Uav.ServiceCeiling").ConvertTo(typeof(int)),
                    Wingspan = (int)valueProvider.GetValue("Uav.Wingspan").ConvertTo(typeof(int)),
                    PowerUnit = (string)valueProvider.GetValue("Uav.PowerUnit").ConvertTo(typeof(string))
                };

                model.Payloads = GetPayloads((string[])valueProvider.GetValue("Payloads").ConvertTo(typeof(string[])), new List<PayloadDTO>());
                model.GcuTypes = GetGcuType((string[])valueProvider.GetValue("GcuType").ConvertTo(typeof(string[])), new List<GcuTypeDTO>());
                return model;
            }

            catch (Exception ex)
            {
                model.BindingError = ex;
                return model;
            }
        }

        private static IEnumerable<GcuTypeDTO> GetGcuType(IEnumerable<string> types, ICollection<GcuTypeDTO> list)
        {
            foreach (var item in types)
            {
                switch (item)
                {
                    case ("1"):
                        list.Add(new PortableDTO() { Id = 1 });
                        break;
                    case ("2"):
                        list.Add(new MobileDTO() { Id = 2 });
                        break;
                    case ("3"):
                        list.Add(new StationaryDTO() { Id = 3 });
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Exception in GetGcuType method ");
                }
            }
            return list;
        }

        private static IEnumerable<PayloadDTO> GetPayloads(IEnumerable<string> types, ICollection<PayloadDTO> list)
        {
            foreach (var item in types)
            {
                switch (item)
                {
                    case ("1"):
                        list.Add(new PhotoDTO() { Id = 1 });
                        break;
                    case ("2"):
                        list.Add(new TVDTO() { Id = 2 });
                        break;
                    case ("3"):
                        list.Add(new IRDTO() { Id = 3 });
                        break;
                    case ("4"):
                        list.Add(new FrontalDTO() { Id = 4 });
                        break;
                    case ("5"):
                        list.Add(new MultispectralDTO() { Id = 5 });
                        break;
                    case ("10"):
                        list.Add(new OtusDTO() { Id = 10 });
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Exception in  GetPayload method");
                }
            }
            return list;
        }
    }
}



