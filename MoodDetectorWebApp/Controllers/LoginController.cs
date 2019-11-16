using System.Web.Mvc;
using ControllerProject;
using ControllerProject.Service;
using MoodDetectorWebApp.Models;
using System.Web.Security;
using System.Security.Principal;

namespace MoodDetectorWebApp.Controllers
{
    public class LoginController : Controller
    {
        private ILoginProcessor _loginProcessor;
        private IUserService _userService;
        private IMoodService _moodService;

        public static string AccessRights = "logged out";
        
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
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            bool loginCorrect = _loginProcessor.ProcessLogin(model.UserName, model.Password);

            if (loginCorrect)
            {
                var user = _userService.GetUser(model.UserName);              

                switch (user.AccessRights)
                {
                    case "Admin":                        
                        FormsAuthentication.SetAuthCookie(model.UserName, false);                       
                        LoginController.AccessRights = "admin";
                        return RedirectToAction("MyProfileAdmin", "MyProfileAdmin");

                    case "Teacher":
                        FormsAuthentication.SetAuthCookie(model.UserName, false);                        
                        LoginController.AccessRights = "teacher";
                        return RedirectToAction("MyProfileTeacher", "MyProfileTeacher");
                }
            }
            else
            {
                LoginController.AccessRights = "logged out";
                ModelState.AddModelError("CustomError", "Incorrect username and/or password");                
                return View("Login");
            }

            return View();            
        }        
    }
}
// **