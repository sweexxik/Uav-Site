using System;
using System.Collections.Generic;
using Main.BLL.DTO;


namespace Main.BLL.Models
{
    /// <summary>
    /// Модель для редактирования сущности PayloadDTO
    /// </summary>
    public class PayloadEditModel
    {
        public PayloadDTO Payload { get; set; }
        public IEnumerable<UavTypeDTO> UavTypes { get; set; }
        public Exception BindingError { get; set; }
    }
}
