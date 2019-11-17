using System.Web.Mvc;

namespace MoodDetectorWebApp.Controllers
{
    public class MyProfileTeacherController : Controller
    {
        // GET: MyProfileTeacher
        [Authorize(Roles = "teacher")]
        public ActionResult MyProfileTeacher()
        {
            return View();
        }
    }
}