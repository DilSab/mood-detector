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

        public void EditUser(AddUser addUser, int id)
        {
            var user = new User()
            {
                Firstname = addUser.Firstname,
                Lastname = addUser.Lastname,
                AccessRights = addUser.AccessRights
            };
            _context.LoginInfoes.Find(id).User = user;
            _context.LoginInfoes.Find(id).Username = addUser.Username;
            _context.LoginInfoes.Find(id).Password = addUser.Password;
            _context.LoginInfoes.Find(id).Email = addUser.Email;
            _context.SaveChanges();
        }

        public string FindUsernameById(int id)
        {
            return _context.LoginInfoes.Find(id).Username;
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

        public AddUser GetAddUser(int id)
        {
            var loginInfo = (from l in _context.LoginInfoes
                        where l.Id == id
                        select l).FirstOrDefault<LoginInfo>();
            var user = GetUser(FindUsernameById(id));
            AddUser addUser = new AddUser(
                loginInfo.Username,
                loginInfo.Password,
                loginInfo.Email,
                user.Firstname,
                user.Lastname,
                user.AccessRights
            );

            return addUser;
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
