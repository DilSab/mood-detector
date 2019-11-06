using System.Web.Mvc;
using ControllerProject;
using ControllerProject.Service;
using MoodDetectorWebApp.Models;

namespace MoodDetectorWebApp.Controllers
{
    public class LoginController : Controller
    {
        private ILoginProcessor _loginProcessor;
        private IUserService _userService;
        private IMoodService _moodService;
        
        public LoginController(ILoginProcessor loginProcessor, IUserService userService, IMoodService moodService)
        {
            _loginProcessor = loginProcessor;
            _userService = userService;
            _moodService = moodService;
        }


        // GET: Login
        public ActionResult Login()
        {
            return View(new LoginModel());
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            bool loginCorrect = _loginProcessor.ProcessLogin(model.UserName, model.Password);

            if (loginCorrect) {
                var user = _userService.GetUser(model.UserName);
                switch (user.AccessRights)
                {
                    case "Admin":
                        return View("~/Views/MyProfileAdmin/MyProfileAdmin.cshtml");
                       
                    case "Teacher":
                        return View("~/Views/MyProfileTeacher/MyProfileTeacher.cshtml");                        
                }
            }

            return View();
        }


    }
}