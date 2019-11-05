using ControllerProject.Service;
using Model;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MoodDetectorWebApp.Controllers
{
    public class ManageUsersController : Controller
    {
        IUserService _userService;

        public ManageUsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult ViewUsers()
        {
            List <User> users = _userService.GetUsers();
            return View("ViewUsers", users);
        }

        // GET: AddUser
        public ActionResult AddUser()
        {
            return View();
        }

        // GET: EditUser
        public ActionResult EditUser()
        {
            return View();
        }

        // GET: DeleteUser
        public ActionResult DeleteUser()
        {
            return View();
        }
    }
}