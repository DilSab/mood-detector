using System;
using System.ComponentModel.DataAnnotations;

namespace MoodDetectorWebApp.Models
{
    public class AddUserModel
    {
        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string Username { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 8)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [StringLength(100, MinimumLength = 10)]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Lastname { get; set; }

        [Required]
        public string AccessRights { get; set; }

        public enum AccessRightsTypes
        {
            Admin = 0,
            Teacher = 1,
        }

        public static string[] GetAllAccessRightsTypes()
        {
            return Enum.GetNames(typeof(AccessRightsTypes));
        }
    }
}
