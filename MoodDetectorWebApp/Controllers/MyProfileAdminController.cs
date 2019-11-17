using ControllerProject.Service;
using System.Web.Mvc;

namespace MoodDetectorWebApp.Controllers
{
    public class MyProfileAdminController : Controller
    {
        private IUserService _userService;
        public MyProfileAdminController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: MyProfileAdmin
        [Authorize(Roles = "admin")]
        public ActionResult MyProfileAdmin()
        {
            var currentUser = _userService.GetUser(System.Web.HttpContext.Current.User.Identity.Name);
            var userInfo = _userService.GetUserWithLogin(currentUser.Id);

            return View(userInfo);
        }
    }
}