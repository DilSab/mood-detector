using Model;
using Model.Entity;
using System.Collections.Generic;

namespace ControllerProject.Service
{
    public interface IUserService
    {
        void AddNewUser(AddUser addUser);

        User GetUser(string username);

        List<User> GetUsers();
    }
}
