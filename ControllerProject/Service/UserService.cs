using Model;
using Model.Entity;
using System.Collections.Generic;
using System.Linq;

namespace ControllerProject.Service
{
    public class UserService : IUserService
    {
        private MoodDetectorDBEntities _context;

        public UserService(MoodDetectorDBEntities context)
        {
            _context = context;
        }

        public void AddNewUser(AddUser addUser)
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

            _context.LoginInfoes.Add(loginInfo);
            _context.SaveChanges();
        }

        public User GetUser(string username)
        {
            var user = (from u in _context.Users
                        from l in _context.LoginInfoes
                        where l.Username == username
                        where u.Id == l.UserId
                        select u).FirstOrDefault<User>();

            return user;
        }

        public List<User> GetUsers()
        {
            List<User> usersList = new List<User>();
            IQueryable<User> users = (from u in _context.Users select u);
            foreach (User user in users)
            {
                usersList.Add(user);
            }
            return usersList;
        }
    }
}
