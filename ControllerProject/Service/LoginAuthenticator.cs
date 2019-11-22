using Model;
using System.Linq;

namespace ControllerProject.Service
{
    public class LoginAuthenticator : ILoginAuthenticator
    {
        private MoodDetectorDbContext _context;

        public LoginAuthenticator(MoodDetectorDbContext context)
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
