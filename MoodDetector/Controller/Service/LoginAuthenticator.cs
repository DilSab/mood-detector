using Model;
using System.Linq;

namespace ControllerProject.Service
{
    public class LoginAuthenticator : ILoginAuthenticator
    {
        private MoodDetectorDBEntities _context;

        public LoginAuthenticator(MoodDetectorDBEntities context)
        {
            _context = context;
        }

        public bool IsLoginCorrect(string username, string password)
        {
                var user = _context.LoginInfoes.FirstOrDefault(u => u.Username == username);
                if (user != null)
                {
                    return user.Password == password ? true : false;
                }

            return false;
        }
    }
}
