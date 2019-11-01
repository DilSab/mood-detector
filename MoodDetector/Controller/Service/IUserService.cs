using Model;
using Model.Entity;

namespace ControllerProject.Service
{
    public interface IUserService
    {
        void AddNewUser(AddUser addUser);

        User GetUser(string username);
    }
}
