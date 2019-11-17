using ControllerProject.Service;
using System.Web.Mvc;

namespace MoodDetectorWebApp.Controllers{
    public class MyProfileTeacherController : Controller
    {
        private IUserService _userService;
        public MyProfileTeacherController(IUserService userService)
        {
            _userService = userService;
        }
        
        // GET: MyProfileTeacher       
        [Authorize(Roles = "teacher")]
        public ActionResult MyProfileTeacher()
        {            
            var currentUser = _userService.GetUser(System.Web.HttpContext.Current.User.Identity.Name);
            var userInfo = _userService.GetUserWithLogin(currentUser.Id);
            
            return View(userInfo);
        }
    }    
}