using Model;
using System.ComponentModel.DataAnnotations;


namespace MoodDetectorWebApp.Models
{
    public class LoginModel
    {        
        public LoginInfo LoginInfo { get; set; }

        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}