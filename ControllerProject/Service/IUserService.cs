using Model;
using Model.Entity;
using System.Collections.Generic;

namespace ControllerProject.Service
{
    public interface IUserService
    {
        void AddNewUser(UserWithLogin addUser, Hash hash);
        void EditUser(UserWithLogin editUser, int id);
        void EditUser(UserWithLogin editUser, int id, Hash hash);
        void DeleteUser(int id);
        string FindUsernameById(int id);
        int FindLoginInfoesIdByUserId(int id);
        User GetUser(string username);
        UserWithLogin GetUserWithLogin(int id);
        List<User> GetUsers();
        List<UserListItem> GetUsersPaginated(int currentPage, int usersPerPage);
        int GetUsersCount();
        List<AccessRightsCount> GetUsersCountGroupByAccessRights();
    }
}
