using System.ComponentModel.DataAnnotations;
using System.Linq;

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
        [StringRange(AllowableValues = new[] { "Admin", "Teacher" }, ErrorMessage = "Access right must be either 'Admin' or 'Teacher'.")]
        public string AccessRights { get; set; }
    }

    public class StringRangeAttribute : ValidationAttribute
    {
        public string[] AllowableValues { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (AllowableValues?.Contains(value?.ToString()) == true)
            {
                return ValidationResult.Success;
            }

            var msg = $"Please enter one of the allowable values: {string.Join(", ", (AllowableValues ?? new string[] { "No allowable values found" }))}.";
            return new ValidationResult(msg);
        }
    }
}