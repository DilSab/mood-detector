using System.Web.Mvc;

namespace MoodDetectorWebApp.Controllers
{
    public class MyProfileAdminController : Controller
    {
        // GET: MyProfileAdmin
        [Authorize(Roles = "admin")]
        public ActionResult MyProfileAdmin()
        {
            return View();
        }
    }
}