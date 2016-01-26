using System.Web.Mvc;
using Main.BLL.Interfaces;

namespace Main.WEB.Controllers
{
    public class GcuController : Controller
    {
        private readonly IGcuTypeService _gcus;

        public GcuController(IGcuTypeService service)
        {
            _gcus = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Portable()
        {
            return View(_gcus.GetPortable());
        }
        
        public ActionResult Mobile()
        {
            return View(_gcus.GetMobile());
        }

        public ActionResult Stationary()
        {
            return View(_gcus.GetStationary());
        }
    }
}