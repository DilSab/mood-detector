using System.ComponentModel.DataAnnotations;

namespace MoodDetectorWebApp.Models
{
    public class AddUserModel
    {
        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Username { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 8)]
        public string Password { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 10)]
        public string Email { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Lastname { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string AccessRights { get; set; }
    }
}