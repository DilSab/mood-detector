using Model;

namespace Controller.Service
{
    public class UserService : IUserService
    {
        public void AddNewUser(string firstname, string lastname, string accessRights)
        {
            using (var context = new MoodDetectorDBEntities())
            {
                var user = new User()
                {
                    Firstname = firstname,
                    Lastname = lastname,
                    AccessRights = accessRights
                };
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}
