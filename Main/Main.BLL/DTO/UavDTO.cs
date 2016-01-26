using System.Collections.Generic;

namespace Main.BLL.DTO
{
    /// <summary>
    ///  Data Transfer Object сущности Uav
    /// </summary>
    public class UavDTO
    {
        public int Id { get; set; }
        public UavTypeDTO Type { get; set; }
        public int FlightRadius { get; set; }
        public string Endurance { get; set; }
        public int MaxSpeed { get; set; }
        public int MinSpeed { get; set; }
        public int TakeoffWeight { get; set; }
        public int Length { get; set; }
        public string TakeoffProcedure { get; set; }
        public string LandingProcedure { get; set; }
        public int ServiceCeiling { get; set; }
        public int Wingspan { get; set; }
        public string PowerUnit { get; set; }

        public IEnumerable<PayloadDTO> Payloads { get; set; }
        public IEnumerable<GcuTypeDTO> GcuTypes { get; set; }

    }
}
