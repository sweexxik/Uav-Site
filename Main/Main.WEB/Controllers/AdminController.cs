using System.Linq;
using System.Web.Mvc;
using Main.BLL.DTO;
using Main.BLL.Interfaces;
using Main.BLL.Models;
using Main.WEB.Models;


namespace Main.WEB.Controllers
{
    /// <summary>
    /// Выполнение действий для просмотра и редактирования всех сущностей приложения (uav, uavtype,payload,gcutype)
    /// Выполнение действий по созданию и удалению сущностей uav & uavtype
    /// </summary>
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _db;

        public AdminController(IAdminService service)
        {
            _db = service;
        }
        
        public ActionResult Index()
        {
            return View(new AdminIndexViewModel()
            {
                Payloads = _db.Payoads,
                Uavs = _db.Uavs,
                GcuTypes = _db.Gcus,
                UavTypes = _db.UavTypes
            });
        }

        public ActionResult Show(string type, int _id = -1)
        {

            if (string.IsNullOrEmpty(type) || _id == -1)
                return Error("Argument Null Erorr");

            switch (type)
            {
                case "uavs":
                    {
                        return _db.GetUav(_id).Id == 0
                            ? Error("error in GetUav method")
                            : View("Uav", _db.GetUav(_id));
                    }
                case "plds":
                    {
                        return _db.GetPayload(_id).Id == 0
                            ? Error("error in GetPayload method")
                            : View("Payload", _db.GetPayload(_id));
                    }
                case "gcus":
                    {
                        return _db.GetGcu(_id).Id == 0
                            ? Error("error in GetGcu method")
                            : View("Gcu", _db.GetGcu(_id));
                    }
                case "uavtypes":
                    {
                        return _db.GetUavType(_id).Id == 0
                            ? Error("error in GetUavTypemethod")
                            : View("UavType", _db.GetUavType(_id));
                    }
                default:
                    return Error("Show method argument exception");
            }
        }

        public ActionResult Edit(string type, int _id = -1)
        {
            if (string.IsNullOrEmpty(type) || _id == -1)
                return Error("Argument Null Erorr");

            switch (type)
            {
                case "uavs":
                    return _db.EditUav(_id).Uav.Id == 0
                        ? Error("Error in EditUav method")
                        : View(_db.EditUav(_id));

                case "plds":
                    return _db.EditPayload(_id).Payload.Id == 0
                        ? Error("Error in EditPayload method")
                        : View("Edit_pld", _db.EditPayload(_id));

                case "gcus":
                    return _db.EditGcu(_id).GcuType.Id == 0
                        ? Error("Error in EditGcu method")
                        : View("Edit_gcu", _db.EditGcu(_id));

                case "uavtypes":
                    return _db.GetUavType(_id).Id == 0
                        ? Error("Error in GetUavType method")
                        : View("Edit_uavType", _db.GetUavType(_id));

                default:
                    return Error("Invalid argument in Edit method");
            }
        }

        [HttpPost]
        public ActionResult EditUav(UavEditModel model)
        {
            if (!ModelState.IsValid || model.BindingError != null)
            {
                TempData["error"] = "Ошибка связывателя: " + model.BindingError.Message;
                return RedirectToAction("index", "admin");
            }

            if (_db.SaveUav(model))
                TempData["success"] = "Изменения в элементе были сохранены";
            else
                TempData["error"] = "Ошибка метода соханения";

            return RedirectToAction("index", "admin");

        }
        
        [HttpPost]
        public ActionResult EditPayload(PayloadEditModel model)
        {
            if (!ModelState.IsValid || model.BindingError != null)
            {
                TempData["error"] = "Ошибка связывателя:" + model.BindingError.Message;
                return RedirectToAction("index", "admin");
            }

            if (_db.SavePayload(model))
                TempData["success"] = "Изменения в элементе были сохранены";
            else
                TempData["error"] = "Ошибка метода соханения";

            return RedirectToAction("show", "admin", new { type = "plds", _id = model.Payload.Id });
        }

        [HttpPost]
        public ActionResult EditGcu(GcuEditModel model)
        {
            if (!ModelState.IsValid || model.BindingError != null)
            {
                TempData["error"] = "Ошибка связывателя:" + model.BindingError.Message;
                return RedirectToAction("index", "admin");
            }

            if (_db.SaveGcu(model))
                TempData["success"] = "Изменения в элементе были сохранены";
            else
                TempData["error"] = "Ошибка метода соханения";

            return RedirectToAction("show", "admin", new { type = "gcus", _id = model.GcuType.Id });
        }

        [HttpPost]
        public ActionResult EditUavType(UavTypeDTO model)
        {
           if (_db.SaveUavType(model))
                TempData["success"] = "Изменения в элементе были сохранены";
            else
                TempData["error"] = "Ошибка метода соханения";

            return RedirectToAction("index", "admin");
        }

        public ActionResult Create(string type)
        {
            switch (type)
            {
                case "uav":
                {
                        return View("CreateUav", new UavEditModel()
                        {
                            Payloads = _db.Payoads.ToList(),
                            Uav = new UavDTO(),
                            GcuTypes = _db.Gcus.ToList(),
                            UavTypes = _db.UavTypes.ToList()

                        });
                    }
                case "uavtypes":
                {
                    return View("CreateUavType", new UavTypeDTO());
                }
                default:
                    return Error("Invalid Create method argument");
            }
        }


        public ActionResult Delete(string type, int _id = -1)
        {
            if (string.IsNullOrEmpty(type) || _id == -1)
                return RedirectToAction("NotFound", "Error", new { ErrorText = "Argument Null Erorr" });

            ViewBag.Id = _id;

            switch (type)
            {
                case "uavs":
                    {
                        if (_db.GetUav(_id).Id == 0)
                            return Error("Invalid \"Delete\" method argument");

                        ViewBag.Name = _db.GetUav(_id).Type.Name;
                        ViewBag.Type = type;
                        return View();
                    }
                case "uavtypes":
                    {
                        if (_db.GetUavType(_id).Id == 0)
                            return Error("Invalid \"Delete\" method argument");

                        ViewBag.Name = _db.GetUavType(_id).Name;
                        ViewBag.Type = type;
                        return View();
                    }
                default:
                    return Error("Invalid \"Delete\" method argument");
            }
        }

        [HttpPost]
        public ActionResult Delete(int _id, string type)
        {
            switch (type)
            {
                case "uavs":
                    {
                        if (_db.DeleteUav(_id))
                            TempData["success"] = "Элемент успешно удален";
                        else
                            TempData["error"] = "Ошибка метода удаления";

                        return RedirectToAction("index", "admin");
                    }
                case "uavtypes":
                    {
                        if (_db.DeleteUavType(_id))
                            TempData["success"] = "Элемент успешно удален";
                        else
                            TempData["error"] = "Ошибка метода удаления";

                        return RedirectToAction("index", "admin");
                    }
                default:
                    return RedirectToAction("index", "admin");
            }
        }
        
        private ActionResult Error(string message)
        {
            return RedirectToAction("NotFound", "Error", new { ErrorText = message });
        }
    }
}