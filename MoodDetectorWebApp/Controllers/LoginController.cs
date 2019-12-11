using System.Web.Mvc;
using ControllerProject;
using ControllerProject.Service;
using MoodDetectorWebApp.Models;
using System.Web.Security;

namespace MoodDetectorWebApp.Controllers
{
    public class LoginController : Controller
    {
        private ILoginProcessor _loginProcessor;
        private IUserService _userService;

        public static string AccessRights = "logged out";
        
        public LoginController(ILoginProcessor loginProcessor, IUserService userService)
        {
            _loginProcessor = loginProcessor;
            _userService = userService;
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

            if (loginCorrect)
            {
                var user = _userService.GetUser(model.UserName);              

                switch (user.AccessRights)
                {
                    case "Admin":                        
                        FormsAuthentication.SetAuthCookie(model.UserName, false);                       
                        AccessRights = "admin";
                        return RedirectToAction("MyProfileAdmin", "MyProfileAdmin");

                    case "Teacher":
                        FormsAuthentication.SetAuthCookie(model.UserName, false);                        
                        AccessRights = "teacher";
                        return RedirectToAction("MyProfileTeacher", "MyProfileTeacher");
                }
            }
            else
            {
                AccessRights = "logged out";
                ModelState.AddModelError("CustomError", "Incorrect username and/or password");                
                return View("~/Views/About/FancyAbout.cshtml");
            }

            return View();            
        }        
    }
}