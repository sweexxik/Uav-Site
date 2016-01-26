using System.Collections.Generic;

namespace Main.BLL.DTO
{
    /// <summary>
    /// Data Transfer Object сущности GcuType
    /// </summary>
    public class GcuTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Places { get; set; }
        public IEnumerable<UavTypeDTO> SupportedUavs { get; set; }
    }

    public class PortableDTO : GcuTypeDTO
    {
        public string DeployTime { get; set; }
    }

    public class MobileDTO : GcuTypeDTO
    {
        public string CarType { get; set; }
    }

    public class StationaryDTO : GcuTypeDTO
    {
        public string DeployPlaces { get; set; }
    }
}
