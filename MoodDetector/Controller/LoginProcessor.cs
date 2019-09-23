using Controller.Service;

namespace Controller
{
    public class LoginProcessor : ILoginProcessor
    {
        private ILoginAuthenticator _loginAuthenticator;

        public LoginProcessor(ILoginAuthenticator loginAuthenticator)
        {
            _loginAuthenticator = loginAuthenticator;
        }

        public bool ProcessLogin(string username, string password)
        {
            if (username == "" || password == "")
            {
                return false;
            }

            return _loginAuthenticator.IsLoginCorrect(username, password) ? true : false;
        }
    }
}
