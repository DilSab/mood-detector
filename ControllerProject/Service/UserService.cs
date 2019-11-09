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
            var loginInfo = _context.LoginInfoes.Find(FindLoginInfoesIdByUserId(id));
            loginInfo.User.Firstname = addUser.Firstname;
            loginInfo.User.Lastname = addUser.Lastname;
            loginInfo.User.AccessRights = addUser.AccessRights;
            loginInfo.Username = addUser.Username;
            loginInfo.Password = addUser.Password;
            loginInfo.Email = addUser.Email;
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var loginInfo = _context.LoginInfoes.Find(FindLoginInfoesIdByUserId(id));
            var user = _context.Users.Find(id);
            _context.LoginInfoes.Remove(loginInfo);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public string FindUsernameById(int id)
        {
            return _context.LoginInfoes.Find(FindLoginInfoesIdByUserId(id)).Username;
        }

        public int FindLoginInfoesIdByUserId(int id)
        {
            var loginInfoes = (from l in _context.LoginInfoes
                          where l.UserId == id
                          select l).FirstOrDefault<LoginInfo>();
            return loginInfoes.Id;
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
            var loginInfoId = FindLoginInfoesIdByUserId(id);
            var loginInfo = (from l in _context.LoginInfoes
                        where l.Id == loginInfoId
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
