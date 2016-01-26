using System.Collections.Generic;
using Main.BLL.DTO;

namespace Main.WEB.Models
{
    /// <summary>
    /// Модель для передачи всех данных о сущностях приложения Index View контроллера Admin
    /// </summary>
    public class AdminIndexViewModel
    {
        public IEnumerable<UavDTO> Uavs { get; set; }
        public IEnumerable<PayloadDTO> Payloads { get; set; }
        public IEnumerable<GcuTypeDTO> GcuTypes { get; set; }
        public IEnumerable<UavTypeDTO> UavTypes { get; set; }
    }
}
