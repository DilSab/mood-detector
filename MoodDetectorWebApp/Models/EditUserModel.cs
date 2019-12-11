using System.ComponentModel.DataAnnotations;

namespace MoodDetectorWebApp.Models
{
    public class EditUserModel
    {
        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string Username { get; set; }

        [Display(Name = "New password")]
        [StringLength(100, MinimumLength = 8)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";

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
    }
}
