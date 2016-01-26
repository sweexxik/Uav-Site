using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Main.BLL.DTO;
using Main.BLL.Models;


namespace Main.BLL.Infrastructure
{
    /// <summary>
    /// Связыватель модели PayloadEditModel для Edit метода Admin контроллера
    /// </summary>
    public class PayloadModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueProvider = bindingContext.ValueProvider;
            var model = new PayloadEditModel();
            
            try
            {
                model.Payload = GetPayload(valueProvider);
                model.UavTypes = GetSupportedUavs(valueProvider);
                return model;
            }
            catch (Exception ex)
            {
                model.BindingError = ex;
                return model;
            }
        }

        private static PayloadDTO GetPayload(IValueProvider valueProvider)
        {
            var id = (string)valueProvider.GetValue("Payload.Id").ConvertTo(typeof(string));

            switch (id)
            {
                case "1":
                    {
                        return new PhotoDTO
                        {
                            Id = (int) valueProvider.GetValue("Payload.Id").ConvertTo(typeof (int)),
                            ImageFormat =(string)valueProvider.GetValue("Payload.ImageFormat").ConvertTo(typeof (string)),
                            Lens = (string)valueProvider.GetValue("Payload.Lens").ConvertTo(typeof (string)),
                            PictureElements = (string) valueProvider.GetValue("Payload.PictureElements").ConvertTo(typeof (string)),
                            PitchRotation = (string) valueProvider.GetValue("Payload.PitchRotation").ConvertTo(typeof (string)),
                            RollingRig = (string) valueProvider.GetValue("Payload.RollingRig").ConvertTo(typeof (string)),
                            Stabilization = (string) valueProvider.GetValue("Payload.Stabilization").ConvertTo(typeof (string)),
                            WatchingCamera = (string) valueProvider.GetValue("Payload.WatchingCamera").ConvertTo(typeof (string)),
                            Weight = (string) valueProvider.GetValue("Payload.Weight").ConvertTo(typeof (string))
                        };
                    }

                case "2":
                    {
                        return new TVDTO
                        {
                            Id = (int) valueProvider.GetValue("Payload.Id").ConvertTo(typeof (int)),
                            EffectivePictureElements = (string)valueProvider.GetValue("Payload.EffectivePictureElements").ConvertTo(typeof (string)),
                            Gimbal = (string) valueProvider.GetValue("Payload.Gimbal").ConvertTo(typeof (string)),
                            LinearResolution = (string) valueProvider.GetValue("Payload.LinearResolution").ConvertTo(typeof (string)),
                            PitchRotation = (string) valueProvider.GetValue("Payload.PitchRotation").ConvertTo(typeof (string)),
                            RollingRig = (string) valueProvider.GetValue("Payload.RollingRig").ConvertTo(typeof (string)),
                            Stabilization = (string) valueProvider.GetValue("Payload.Stabilization").ConvertTo(typeof (string)),
                            Zoom = (string) valueProvider.GetValue("Payload.Zoom").ConvertTo(typeof (string)),
                            Weight = (string) valueProvider.GetValue("Payload.Weight").ConvertTo(typeof (string))
                        };
                    }

                case "3":
                    {
                        return new IRDTO
                        {
                            Id = (int)valueProvider.GetValue("Payload.Id").ConvertTo(typeof(int)),
                            DispalyFormat = (string)valueProvider.GetValue("Payload.DispalyFormat").ConvertTo(typeof(string)),
                            Lens = (string)valueProvider.GetValue("Payload.Lens").ConvertTo(typeof(string)),
                            FullFrameRates = (string)valueProvider.GetValue("Payload.FullFrameRates").ConvertTo(typeof(string)),
                            PitchRotation = (string)valueProvider.GetValue("Payload.PitchRotation").ConvertTo(typeof(string)),
                            RollingRig = (string)valueProvider.GetValue("Payload.RollingRig").ConvertTo(typeof(string)),
                            Stabilization = (string)valueProvider.GetValue("Payload.Stabilization").ConvertTo(typeof(string)),
                            WatchingCamera = (string)valueProvider.GetValue("Payload.WatchingCamera").ConvertTo(typeof(string)),
                            HorizontalResolution = (string)valueProvider.GetValue("Payload.HorizontalResolution").ConvertTo(typeof(string)),
                            Gimbal = (string)valueProvider.GetValue("Payload.Gimbal").ConvertTo(typeof(string)),
                            LinearResolution = (string)valueProvider.GetValue("Payload.LinearResolution").ConvertTo(typeof(string)),
                            SpectralBand = (string)valueProvider.GetValue("Payload.SpectralBand").ConvertTo(typeof(string)),
                            Weight = (string)valueProvider.GetValue("Payload.Weight").ConvertTo(typeof(string))

                        };
                    }

                case "4":
                    {
                       return new FrontalDTO
                        {
                            Id = (int) valueProvider.GetValue("Payload.Id").ConvertTo(typeof (int)),
                            AngleOfView = (string) valueProvider.GetValue("Payload.AngleOfView").ConvertTo(typeof (string)),
                            Lens = (string) valueProvider.GetValue("Payload.Lens").ConvertTo(typeof (string)),
                            Definition = (string) valueProvider.GetValue("Payload.Definition").ConvertTo(typeof (string)),
                            SpectralBand = (string)valueProvider.GetValue("Payload.SpectralBand").ConvertTo(typeof(string)),
                            Weight = (string)valueProvider.GetValue("Payload.Weight").ConvertTo(typeof(string))
                        };
                    }

                case "5":
                    {
                        return new MultispectralDTO
                        {
                            Id = (int) valueProvider.GetValue("Payload.Id").ConvertTo(typeof (int)),
                            CameraCoverage = (string) valueProvider.GetValue("Payload.CameraCoverage").ConvertTo(typeof (string)),
                            Dimensions = (string) valueProvider.GetValue("Payload.Dimensions").ConvertTo(typeof (string)),
                            ImageResolution = (string) valueProvider.GetValue("Payload.ImageResolution").ConvertTo(typeof (string)),
                            MeasurementRange = (string) valueProvider.GetValue("Payload.MeasurementRange").ConvertTo(typeof (string)),
                            RateOfFrameRecording = (string)valueProvider.GetValue("Payload.RateOfFrameRecording").ConvertTo(typeof (string)),
                            ResolutionOfCourseCamera = (string)valueProvider.GetValue("Payload.ResolutionOfCourseCamera").ConvertTo(typeof (string)),
                            Weight = (string) valueProvider.GetValue("Payload.Weight").ConvertTo(typeof (string))
                        };
                  }

                case "10":
                    {
                       return new OtusDTO
                        {
                            Id = (int) valueProvider.GetValue("Payload.Id").ConvertTo(typeof (int)),
                            Feedback = (string) valueProvider.GetValue("Payload.Feedback").ConvertTo(typeof (string)),
                            GimbalSystem = (string) valueProvider.GetValue("Payload.GimbalSystem").ConvertTo(typeof (string)),
                            Interfaces = (string) valueProvider.GetValue("Payload.Interfaces").ConvertTo(typeof (string)),
                            PanTilRange = (string) valueProvider.GetValue("Payload.PanTilRange").ConvertTo(typeof (string)),
                            RangeFinder = (string) valueProvider.GetValue("Payload.RangeFinder").ConvertTo(typeof (string)),
                            Stabiliz = (string) valueProvider.GetValue("Payload.Stabiliz").ConvertTo(typeof (string)),
                            Temperature = (string) valueProvider.GetValue("Payload.Temperature").ConvertTo(typeof (string)),
                            Weight = (string) valueProvider.GetValue("Payload.Weight").ConvertTo(typeof (string))
                        };
                    }

                default: throw new IndexOutOfRangeException("Payload ID is out of range");
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
