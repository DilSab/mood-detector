using ControllerProject.Service;
using Model;
using Model.Entity;
using MoodDetectorWebApp.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MoodDetectorWebApp.Controllers
{
    public class ManageUsersController : Controller
    {
        IUserService _userService;
        IRegisterAuthenticator _registerAuthenticator;

        public ManageUsersController(IUserService userService, IRegisterAuthenticator registerAuthenticator)
        {
            _userService = userService;
            _registerAuthenticator = registerAuthenticator;
        }

        [HttpGet]
        public ActionResult ViewUsers()
        {
            List<User> users = _userService.GetUsers();
            return View("ViewUsers", users);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            return View("AddUser");
        }

        [HttpPost]
        public ActionResult AddUser(AddUserModel addUserModel)
        {
            UserWithLogin addUser = new UserWithLogin(
                addUserModel.Username,
                addUserModel.Password,
                addUserModel.Email,
                addUserModel.Firstname,
                addUserModel.Lastname,
                addUserModel.AccessRights
                );
            if (!_registerAuthenticator.IsRegisterDataCorrect(addUser))
            {
                return View("ErrorMessage", model: "Check entered data");
            }
            _userService.AddNewUser(addUser);
            return View("SuccessfulAdd");
        }

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            var user = _userService.GetUserWithLogin(id);
            return View("EditUser", user);
        }

        [HttpPost]
        public ActionResult EditUser(AddUserModel addUserModel, int id)
        {
            UserWithLogin editUser = new UserWithLogin(
                addUserModel.Username,
                addUserModel.Password,
                addUserModel.Email,
                addUserModel.Firstname,
                addUserModel.Lastname,
                addUserModel.AccessRights
                );
            /*if (!_registerAuthenticator.IsRegisterDataCorrect(addUser))
            {
                return View("DeleteUser");
            }*/
            _userService.EditUser(editUser, id);
            return View("SuccessfulAdd");
        }

        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            return View("DeleteUser", _userService.GetUser(_userService.FindUsernameById(id)));
        }

        public ActionResult DeleteUserPost(int id)
        {
            _userService.DeleteUser(id);
            return View("SuccessfulAdd");
        }
    }
}