using System.Web.Mvc;

namespace MoodDetectorWebApp.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Logout
        public ActionResult Logout()
        {
            return View();
        }
    }
}