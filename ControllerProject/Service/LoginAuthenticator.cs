using Model;
using System.Linq;

namespace ControllerProject.Service
{
    public class LoginAuthenticator : ILoginAuthenticator
    {
        private MoodDetectorDbContext _context;
        private IEncryptor _encryptor;

        public LoginAuthenticator(MoodDetectorDbContext context, IEncryptor encryptor)
        {
            _context = context;
            _encryptor = encryptor;
        }

        public bool IsLoginCorrect(string username, string password)
        {
                var loginInfo = _context.LoginInfoes.FirstOrDefault(u => u.Username == username);
                if (loginInfo != null)
                {
                    return _encryptor.IsHashMathing(loginInfo.Hash, password, loginInfo.Salt);
                }

            return false;
        }
    }
}
