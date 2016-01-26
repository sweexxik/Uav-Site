using System;
using System.Collections.Generic;
using Main.BLL.DTO;


namespace Main.BLL.Models
{
    /// <summary>
    /// Модель для редактирования сущности GcuTypeDTO
    /// </summary>
    public class GcuEditModel
    {
        public GcuTypeDTO GcuType { get; set; }
        public IEnumerable<UavTypeDTO> UavTypes { get; set; }
        public Exception BindingError { get; set; }
    }
}
