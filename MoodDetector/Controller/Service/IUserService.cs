using Model;

namespace Controller.Service
{
    public interface IUserService
    {
        void AddNewUser(string firstname, string lastname, string accessRights);

        User GetUser(string username);
    }
}