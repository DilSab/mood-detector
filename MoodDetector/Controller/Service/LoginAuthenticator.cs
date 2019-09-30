using Model;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Controller.Service
{
    public class LoginAuthenticator : ILoginAuthenticator
    {
        public bool IsLoginCorrect(string username, string password)
        {
            using (MoodDetectorDBEntities context = new MoodDetectorDBEntities())
            {
                var user = context.LoginInfoes.FirstOrDefault(u => u.Username == username);
                if (user != null)
                {
                    return user.Password == password ? true : false;
                }
            }

            return false;
        }
    }
}
