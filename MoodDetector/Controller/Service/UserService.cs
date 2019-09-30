using Model;
using Model.Entity;
using System.Linq;

namespace Controller.Service
{
    public class UserService : IUserService
    {
        public void AddNewUser(AddUser addUser)
        {
            using (var context = new MoodDetectorDBEntities())
            {
                var loginInfo = new LoginInfo()
                {
                    User = new User()
                    {
                        Firstname = addUser.Firstname,
                        Lastname = addUser.Lastname,
                        AccessRights = addUser.AccessRights
                    },
                    Username = addUser.Username,
                    Password = addUser.Password,
                    Email = addUser.Email
                };
                context.LoginInfoes.Add(loginInfo);
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
