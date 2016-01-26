using System.Web.Mvc;
using Main.BLL.Interfaces;

namespace Main.WEB.Controllers
{
    public class PayloadsController : Controller
    {
        private readonly IPayloadService _payloads;
  
        public PayloadsController(IPayloadService repository)
        {
            _payloads = repository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TV()
        {
            return View(_payloads.GetTV());
        }
        
        public ActionResult IR()
        {
            return View(_payloads.GetIR());
        }

        public ActionResult Photo()
        {

            return View(_payloads.GetPhoto());
        }

        public ActionResult Multispectral()
        {
            return View(_payloads.GetMultispectral());
        }

        public ActionResult Frontal()
        {
            return View(_payloads.GetFrontal());
        }

        public ActionResult Otus()
        {

            return View(_payloads.GetOtus());
        }


    }
}