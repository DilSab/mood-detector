using Model;
using System.Data;
using System.Data.SqlClient;

namespace Controller.Service
{
    public class LoginAuthenticator : ILoginAuthenticator
    {
        private IUserCounter _userCounter;

        public LoginAuthenticator(IUserCounter userCounter)
        {
            _userCounter = userCounter;
        }

        public bool IsLoginCorrect(string username, string password)
        {
            if (username == "" || password == "")
            {
                return false;
            }
            int userCount = _userCounter.GetUserCount(username, password);

            return userCount == 1 ? true : false;
        }
    }
}
