using Model;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace ControllerProject.Service
{
    public class UserService : IUserService
    {
        private MoodDetectorDbContext _context;

        public UserService(MoodDetectorDbContext context)
        {
            _context = context;
        }

        public void AddNewUser(UserWithLogin addUser, Hash hash)
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
                Salt = hash.Salt,
                Hash = hash.SaltedHash,
                Email = addUser.Email
            };

            _context.LoginInfoes.Add(loginInfo);
            _context.SaveChanges();
        }

        public void EditUser(UserWithLogin editUser, int id)
        {
            var loginInfo = _context.LoginInfoes.Find(FindLoginInfoesIdByUserId(id));
            loginInfo.User.Firstname = editUser.Firstname;
            loginInfo.User.Lastname = editUser.Lastname;
            loginInfo.User.AccessRights = editUser.AccessRights;
            loginInfo.Username = editUser.Username;
            loginInfo.Email = editUser.Email;

            _context.SaveChanges();
        }

        public void EditUser(UserWithLogin editUser, int id, Hash hash)
        {
            var loginInfo = _context.LoginInfoes.Find(FindLoginInfoesIdByUserId(id));
            loginInfo.User.Firstname = editUser.Firstname;
            loginInfo.User.Lastname = editUser.Lastname;
            loginInfo.User.AccessRights = editUser.AccessRights;
            loginInfo.Username = editUser.Username;
            loginInfo.Salt = hash.Salt;
            loginInfo.Hash = hash.SaltedHash;
            loginInfo.Email = editUser.Email;

            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var loginInfo = _context.LoginInfoes.Find(FindLoginInfoesIdByUserId(id));
            var user = loginInfo.User;
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

        public UserWithLogin GetUserWithLogin(int id)
        {
            var loginInfoId = FindLoginInfoesIdByUserId(id);
            var loginInfo = (from l in _context.LoginInfoes
                        where l.Id == loginInfoId
                        select l).FirstOrDefault<LoginInfo>();
            var user = GetUser(FindUsernameById(id));
            UserWithLogin userWithLogin = new UserWithLogin(
                loginInfo.Username,
                loginInfo.Email,
                user.Firstname,
                user.Lastname,
                user.AccessRights
            );

            return userWithLogin;
        }

        public List<User> GetUsers()
        {
            List<User> usersList = new List<User>();
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MoodDetectorDB"].ConnectionString))
            {
                string command = "SELECT * FROM Users";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                DataTable table = new DataTable();
                adapter.Fill(table);

                foreach (DataRow row in table.Rows)
                {
                    User user = new User()
                    {
                        Id = Convert.ToInt32(row["Id"].ToString()),
                        Firstname = row["Firstname"].ToString(),
                        Lastname = row["Lastname"].ToString(),
                        AccessRights = row["AccessRights"].ToString(),
                    };

                    usersList.Add(user);
                }

                return usersList;
            }
        }

        public List<User> GetUsersPaginated(int currentPage, int usersPerPage)
        {
            var users = (from u in _context.Users
                         where u.AccessRights != "Admin"
                         orderby u.Id ascending
                         select u)
                         .Skip((currentPage - 1) * usersPerPage)
                         .Take(usersPerPage)
                         .ToList();

            return users;
        }

        public int GetUsersCount()
        {
            var count = (from u in _context.Users
                         where u.AccessRights != "Admin"
                         select u).Count();

            return count;
        }
    }
}
