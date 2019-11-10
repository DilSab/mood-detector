using Model;
using Model.Entity;
using System.Collections.Generic;

namespace ControllerProject.Service
{
    public interface IUserService
    {
        void AddNewUser(UserWithLogin addUser);

        void EditUser(UserWithLogin addUser, int id);

        void DeleteUser(int id);

        string FindUsernameById(int id);

        int FindLoginInfoesIdByUserId(int id);

        User GetUser(string username);

        UserWithLogin GetUserWithLogin(int id);

        List<User> GetUsers();
    }
}
