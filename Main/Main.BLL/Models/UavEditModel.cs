using System;
using System.Collections.Generic;
using Main.BLL.DTO;

namespace Main.BLL.Models
{
    /// <summary>
    /// Модель для редактирования сущности UavDTO
    /// </summary>
    public class UavEditModel
    {
        public UavDTO Uav { get; set; }
        public IEnumerable<PayloadDTO> Payloads { get; set; }
        public IEnumerable<GcuTypeDTO> GcuTypes { get; set; }
        public IEnumerable<UavTypeDTO> UavTypes { get; set; }
        public Exception BindingError { get; set; }
    }
}
