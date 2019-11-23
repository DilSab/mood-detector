using ControllerProject.Service;
using Model;
using Model.Entity;
using MoodDetectorWebApp.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MoodDetectorWebApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class ManageUsersController : Controller
    {
        private IUserService _userService;
        private IEncryptor _encryptor;

        public ManageUsersController(IUserService userService, IEncryptor encryptor)
        {
            _userService = userService;
            _encryptor = encryptor;
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
        [ValidateAntiForgeryToken]
        public ActionResult AddUser(AddUserModel addUserModel)
        {
            if (ModelState.IsValid)
            {
                UserWithLogin addUser = new UserWithLogin(
                    addUserModel.Username,
                    addUserModel.Email,
                    addUserModel.Firstname,
                    addUserModel.Lastname,
                    addUserModel.AccessRights
                );

                _userService.AddNewUser(addUser, _encryptor.GetHash(addUserModel.Password));

                return View("SuccessfulAdd");
            }

            return View("~/Views/ManageUsers/AddUser.cshtml", addUserModel);
        }

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            var user = _userService.GetUserWithLogin(id);
            EditUserModel editUserModel = new EditUserModel()
            {
                Username = user.Username,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email
            };

            return View("EditUser", editUserModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser(EditUserModel editUserModel, int id)
        {
            if (ModelState.IsValid)
            {
                UserWithLogin editUser = new UserWithLogin(
                    editUserModel.Username,
                    editUserModel.Email,
                    editUserModel.Firstname,
                    editUserModel.Lastname
                );
                if (editUserModel.Password != null && editUserModel.Password.Trim() != "")
                {
                    var hash = _encryptor.GetHash(editUserModel.Password);
                    _userService.EditUser(editUser, id, hash);
                }
                _userService.EditUser(editUser, id);
                
                return View("SuccessfulAdd");
            }

            return View("~/Views/ManageUsers/AddUser.cshtml", editUserModel);
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
