using System.Web.Mvc;
using Main.BLL.Interfaces;


namespace Main.WEB.Controllers
{
    public class UavsController : Controller
    {
        private readonly IUavService _uavs;

        public UavsController(IUavService service)
        {
            _uavs = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BuselM()
        {
            return View(_uavs.GetUav(1));
        }

        public ActionResult BuselM50()
        {
            return View(_uavs.GetUav(2));
        }

        public ActionResult Bur()
        {
            return View(_uavs.GetUav(3));
        }

        public ActionResult BakEm()
        {

            return View(_uavs.GetUav(4));
        }
    }
}