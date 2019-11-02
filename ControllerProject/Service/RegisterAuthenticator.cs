using Model.Entity;
using System.Linq;
using System.Text.RegularExpressions;

namespace ControllerProject.Service
{
    public class RegisterAuthenticator : IRegisterAuthenticator
    {
        public bool IsRegisterDataCorrect(AddUser addUser)
        {
            Regex regex;
            regex = new Regex(@"^[a-z0-9][-a-z0-9._]+@([-a-z0-9]+[.])+[a-z]{2,5}$");
            Match match = regex.Match(addUser.Email);
            if (!match.Success) return false;
            if (!addUser.Password.Any(char.IsUpper)) return false;
            if (!addUser.Password.Any(char.IsDigit)) return false;
            if (addUser.Password.Length < 8) return false;
            if (!addUser.AccessRights.Equals("Admin") && !addUser.AccessRights.Equals("Teacher")) return false;
            if (string.IsNullOrWhiteSpace(addUser.AccessRights)) return false;
            if (string.IsNullOrWhiteSpace(addUser.Email)) return false;
            if (string.IsNullOrWhiteSpace(addUser.Firstname)) return false;
            if (string.IsNullOrWhiteSpace(addUser.Lastname)) return false;
            if (string.IsNullOrWhiteSpace(addUser.Password)) return false;
            if (string.IsNullOrWhiteSpace(addUser.Username)) return false;

            return true;
        } 
    }
}
