using Model;
using Model.Entity;
using System.Collections.Generic;

namespace ControllerProject.Service
{
    public interface IUserService
    {
        void AddNewUser(AddUser addUser);

        void EditUser(AddUser addUser, int id);

        string FindUsernameById(int id);

        User GetUser(string username);

        AddUser GetAddUser(int id);

        List<User> GetUsers();
    }
}
