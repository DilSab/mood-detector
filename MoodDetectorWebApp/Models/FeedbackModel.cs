using Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace MoodDetectorWebApp.Models
{
    public class FeedbackModel
    {
        public User User { get; set; }
        public string EmotionName { get; set; }

        [Required]
        public string Comments { get; set; }
    }
}