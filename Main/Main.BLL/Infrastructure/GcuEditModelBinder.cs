using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Main.BLL.DTO;
using Main.BLL.Models;


namespace Main.BLL.Infrastructure
{
    /// <summary>
    /// Связыватель модели GcuEditModel для Edit метода Admin контроллера
    /// </summary>
    public class GcuModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueProvider = bindingContext.ValueProvider;
            var model = new GcuEditModel();

            try
            {
                model.GcuType = GetGcu(valueProvider);
                model.UavTypes = GetSupportedUavs(valueProvider);
                return model;
            }
            catch (Exception ex)
            {
                model.BindingError = ex;
                return model;
            }
        }
        
        private static GcuTypeDTO GetGcu(IValueProvider valueProvider)
        {
            var id = (string)valueProvider.GetValue("GcuType.Id").ConvertTo(typeof(string));

            switch (id)
            {
                case "1":
                    {
                        var gcu = new PortableDTO
                        {
                            Id = (int)valueProvider.GetValue("GcuType.Id").ConvertTo(typeof(int)),
                            Name = (string)valueProvider.GetValue("GcuType.Name").ConvertTo(typeof(string)),
                            Size = (string)valueProvider.GetValue("GcuType.Size").ConvertTo(typeof(string)),
                            DeployTime = (string)valueProvider.GetValue("GcuType.DeployTime").ConvertTo(typeof(string)),
                            Places = (string)valueProvider.GetValue("GcuType.Places").ConvertTo(typeof(string))
                        };
                        return gcu;
                    }

                case "2":
                    {
                        var gcu = new MobileDTO
                        {
                            Id = (int)valueProvider.GetValue("GcuType.Id").ConvertTo(typeof(int)),
                            Name = (string)valueProvider.GetValue("GcuType.Name").ConvertTo(typeof(string)),
                            Size = (string)valueProvider.GetValue("GcuType.Size").ConvertTo(typeof(string)),
                            CarType = (string)valueProvider.GetValue("GcuType.CarType").ConvertTo(typeof(string)),
                            Places = (string)valueProvider.GetValue("GcuType.Places").ConvertTo(typeof(string))
                        };
                        return gcu;
                    }
                case "3":
                    {
                        var gcu = new StationaryDTO
                        {
                            Id = (int)valueProvider.GetValue("GcuType.Id").ConvertTo(typeof(int)),
                            Name = (string)valueProvider.GetValue("GcuType.Name").ConvertTo(typeof(string)),
                            Size = (string)valueProvider.GetValue("GcuType.Size").ConvertTo(typeof(string)),
                            DeployPlaces = (string)valueProvider.GetValue("GcuType.DeployPlaces").ConvertTo(typeof(string)),
                            Places = (string)valueProvider.GetValue("GcuType.Places").ConvertTo(typeof(string))
                        };
                        return gcu;
                    }

                default: throw new IndexOutOfRangeException("Exception in GetGcu method");
            }

        }

        private static IEnumerable<UavTypeDTO> GetSupportedUavs(IValueProvider valueProvider)
        {
            if (valueProvider.GetValue("UavType") == null)
                throw new Exception("UavTypes is NULL");

            var types = (string[]) valueProvider.GetValue("UavType").ConvertTo(typeof (string[]));

            return types.Select(item => new UavTypeDTO()
            {
                Id = int.Parse(item)
            }).ToList();
        }
    }
}

