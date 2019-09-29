using Model;
using System.Linq;

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

        public User GetUser(string username)
        {
            using (var context = new MoodDetectorDBEntities())
            {
                return context.Users.SqlQuery("SELECT * FROM [User], LoginInfo WHERE [User].Id=UserId AND Username='" + username + "'").FirstOrDefault<User>();           
            }
        }
    }
}
