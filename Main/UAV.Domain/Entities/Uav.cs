using System.Collections.Generic;

namespace UAV.Domain.Entities
{
    /// <summary>
    /// Беспилотный летатательный аппарат.
    /// Включает общие параметры, а также списки поддерживаемых типов НПУ и ЦН
    /// </summary>
    public class Uav
    {
        public  int  Id { get; set; }
        public virtual UavType Type { get; set; }
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

        public virtual List<Payload> Payloads { get; set; }
        public virtual List<GcuType> GcuTypes { get; set; }
    }
}
