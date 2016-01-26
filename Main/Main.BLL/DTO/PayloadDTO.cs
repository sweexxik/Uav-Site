using System.Collections.Generic;

namespace Main.BLL.DTO
{
    /// <summary>
    ///  Data Transfer Object сущности Payload
    /// </summary>
    public class PayloadDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Weight { get; set; }
        public IEnumerable<UavTypeDTO> SupportedUavs { get; set; }
    }

    public class TVDTO : PayloadDTO
    {
        public string EffectivePictureElements { get; set; }
        public string Zoom { get; set; }
        public string Gimbal { get; set; }
        public string Stabilization { get; set; }
        public string LinearResolution { get; set; }
        public string RollingRig { get; set; }
        public string PitchRotation { get; set; }
    }

    public class IRDTO : PayloadDTO
    {
        public string DispalyFormat { get; set; }
        public string Lens { get; set; }
        public string SpectralBand { get; set; }
        public string Stabilization { get; set; }
        public string FullFrameRates { get; set; }
        public string WatchingCamera { get; set; }
        public string HorizontalResolution { get; set; }
        public string Gimbal { get; set; }
        public string RollingRig { get; set; }
        public string PitchRotation { get; set; }
        public string LinearResolution { get; set; }
    }


    public class FrontalDTO : PayloadDTO
    {
        public string Definition { get; set; }
        public string Lens { get; set; }
        public string SpectralBand { get; set; }
        public string AngleOfView { get; set; }
    }

    public class PhotoDTO : PayloadDTO
    {
        public string ImageFormat { get; set; }
        public string Lens { get; set; }
        public string PictureElements { get; set; }
        public string WatchingCamera { get; set; }
        public string Stabilization { get; set; }
        public string RollingRig { get; set; }
        public string PitchRotation { get; set; }

    }

    public class MultispectralDTO : PayloadDTO
    {
        public string MeasurementRange { get; set; }
        public string ImageResolution { get; set; }
        public string RateOfFrameRecording { get; set; }
        public string CameraCoverage { get; set; }
        public string ResolutionOfCourseCamera { get; set; }
        public string Dimensions { get; set; }
    }

    public class OtusDTO : PayloadDTO
    {
        public string GimbalSystem { get; set; }
        public string Stabiliz { get; set; }
        public string RangeFinder { get; set; }
        public string PanTilRange { get; set; }
        public string Interfaces { get; set; }
        public string Feedback { get; set; }
        public string Temperature { get; set; }

    }

}