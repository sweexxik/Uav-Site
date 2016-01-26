using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UAV.Domain.Entities
{
    /// <summary>
    /// Тип назменого Целевой Нагрузки БЛА. Базовый класс описывает общий функционал всех ЦН,
    /// наследуемые классы включают более специфические параметры
    /// </summary>
    public class Payload
    {
        public const string Message = "Поле не должно быть пустым";

        [HiddenInput]
        public int Id { get; set; }

        [Display(Name = "Тип")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string Type { get; set; }

        [Display(Name = "Вес")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string Weight { get; set; }

        public virtual List<Uav> SupportedUavs { get; set; }

    }
    
    public class TV : Payload
    {

        [Display(Name = "Эффективные элементы изображения")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string EffectivePictureElements { get; set; }

        [Display(Name = "Приближение")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string Zoom { get; set; }

        [Display(Name = "Видеосистема")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string Gimbal { get; set; }

        [Display(Name = "Стабилизация")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string Stabilization { get; set; }

        [Display(Name = "Линейное разрешение")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string LinearResolution { get; set; }

        [Display(Name = "Поворот по оси крена")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string RollingRig { get; set; }

        [Display(Name = "Поворот по оси тангажа")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string PitchRotation { get; set; }
    }

    public class IR : Payload
    {
        [Display(Name = "Формат отображения")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string DispalyFormat { get; set; }

        [Display(Name = "Линза")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string Lens { get; set; }

        [Display(Name = "Спектральный анализ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string SpectralBand { get; set; }

        [Display(Name = "Стабилизация")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string Stabilization { get; set; }

        [Display(Name = "Полнокадровая частота")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string FullFrameRates { get; set; }

        [Display(Name = "Курсовая камера")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string WatchingCamera { get; set; }

        [Display(Name = "Горизонтальное разрешение")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string HorizontalResolution { get; set; }

        [Display(Name = "Видеосистема")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string Gimbal { get; set; }

        [Display(Name = "Поворот по оси")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string RollingRig { get; set; }

        [Display(Name = "Поворот по оси тангажа")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string PitchRotation { get; set; }

        [Display(Name = "Линейное разрешение")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string LinearResolution { get; set; }
    }


    public class Frontal : Payload
    {
        [Display(Name = "Разрешение")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string Definition { get; set; }

        [Display(Name = "Линза")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string Lens { get; set; }

        [Display(Name = "Спектр частот")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string SpectralBand { get; set; }

        [Display(Name = "Угол зрения")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string AngleOfView { get; set; }
    }

    public class Photo : Payload
    {
        [Display(Name = "Формат изображения")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string ImageFormat { get; set; }

        [Display(Name = "Линза")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string Lens { get; set; }

        [Display(Name = "Элементы отображения")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string PictureElements { get; set; }

        [Display(Name = "Курсовая камера")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string WatchingCamera { get; set; }

        [Display(Name = "Стабилизация")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string Stabilization { get; set; }

        [Display(Name = "Поворот по углу крена")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string RollingRig { get; set; }

        [Display(Name = "Поворот по углу тангажа")]
        [Required(AllowEmptyStrings = false, ErrorMessage = Message)]
        public string PitchRotation { get; set; }

    }

    public class Multispectral : Payload
    {

        [Display(Name = "Диапазон измерения")]
        public string MeasurementRange { get; set; }

        [Display(Name = "Разрешение изображения")]
        public string ImageResolution { get; set; }

        [Display(Name = "Частота записи кадров")]
        public string RateOfFrameRecording { get; set; }

        [Display(Name = "Покрытие камеры")]
        public string CameraCoverage { get; set; }

        [Display(Name = "Разрешение курсовой камеры")]
        public string ResolutionOfCourseCamera { get; set; }

        [Display(Name = "Размеры")]
        public string Dimensions { get; set; }
    }

    public class Otus : Payload
    {
        [Display(Name = "Видеосистема")]
        public string GimbalSystem { get; set; }

        [Display(Name = "Стабилизация")]
        public string Stabiliz { get; set; }

        [Display(Name = "Диапазон")]
        public string RangeFinder  { get; set; }

        [Display(Name = "диапазон")]
        public string PanTilRange { get; set; }

        [Display(Name = "Интерфейс")]
        public string Interfaces { get; set; }

        [Display(Name = "Отклик")]
        public string Feedback { get; set; }

        [Display(Name = "Температура")]
        public string Temperature { get; set; }
    }
    
}
