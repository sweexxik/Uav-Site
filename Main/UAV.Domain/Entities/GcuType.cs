using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UAV.Domain.Entities
{
    /// <summary>
    /// Тип назменого пункта управления
    /// Базовый класс описывает общий функционал всех НПУ (включая список оддерживаемых типов БЛА)
    /// Наследуемые классы включают более специфические параметры
    /// </summary>
    public class GcuType
    {
        public const string Message = "Поле не должно быть пустым";

        public int Id { get; set; }

        [Display(Name = "Эффективные элементы изображения ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string Name { get; set; }

        [Display(Name = "Размеры")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string Size { get; set; }

        [Display(Name = "Количество рабочих мест")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string Places { get; set; }

        public virtual List<Uav> SupportedUavs { get; set; }
    }

    public class Portable : GcuType
    {
        [Display(Name = "Время развертывания")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string DeployTime { get; set; }
    }

    public class Mobile : GcuType
    {
        [Display(Name = "Колесная база")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string CarType { get; set; }
    }

    public class Stationary : GcuType
    {
        [Display(Name = "Места развертывания")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
      public string DeployPlaces { get; set; }
    }

}
