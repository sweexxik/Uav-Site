using System.Web.Mvc;

namespace Main.WEB.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound(string errorText)
        {
            ViewBag.Error = errorText ?? "invalid URL";
            return View("Error");
        }
    }
}