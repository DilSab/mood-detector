using Controller.Service;
using System.Security.Authentication;

namespace Controller
{
    public class LoginProcessor : ILoginProcessor
    {
        ILoginAuthenticator _loginAuthenticator;
        IUserInfoReceiver _userInfoReceiver;

        public LoginProcessor(ILoginAuthenticator loginAuthenticator, IUserInfoReceiver userInfoReceiver)
        {
            _loginAuthenticator = loginAuthenticator;
            _userInfoReceiver = userInfoReceiver;
        }

        public bool ProcessLogin(string username, string password)
        {
            if (_loginAuthenticator.IsLoginCorrect(username, password))
            {
                return true;
            }
            else
            {
                throw new AuthenticationException();
            }
        }
    }
}
