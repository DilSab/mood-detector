using System.ComponentModel.DataAnnotations;

namespace MoodDetectorWebApp.Models
{
    public class JoinSessionModel
    {
        [Required]
        [Range(1, 9999, ErrorMessage = "Session ID should be between {1} and {2}.")]
        public int DetectionId { get; set; }
        [Required(ErrorMessage = "Enter your name to join. Name should be 2-15 letters long")]
        [StringLength(15, MinimumLength = 2)]
        public string JoinName { get; set; }

        public string VideoId { get; set; }
    }
}