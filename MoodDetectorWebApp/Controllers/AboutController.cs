using System.Web.Mvc;

namespace MoodDetectorWebApp.Controllers
{
    public class AboutController : Controller
    {

        public ActionResult Detector()
        {
            ViewBag.Message = "Recognise emotions in photos";

            return View();
        }

        public ActionResult FancyAbout()
        {
            return View();
        }
    }
}