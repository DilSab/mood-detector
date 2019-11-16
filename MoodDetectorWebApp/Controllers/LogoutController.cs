using System.Web.Mvc;
using System.Web.Security;
namespace MoodDetectorWebApp.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            LoginController.AccessRights = "logged out";
            return RedirectToAction("About", "About");
        }
    }
}