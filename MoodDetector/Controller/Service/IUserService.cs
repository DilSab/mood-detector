using Model;
using Model.Entity;

namespace Controller.Service
{
    public interface IUserService
    {
        void AddNewUser(AddUser addUser);

        User GetUser(string username);
    }
}
