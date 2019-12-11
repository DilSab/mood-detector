using System.ComponentModel.DataAnnotations;

namespace MoodDetectorWebApp.Models
{
    public class EditLearningModel
    {
        [Required]
        [StringLength(200, MinimumLength = 4)]
        public string Text { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 4)]
        public string Link { get; set; }
    }
}