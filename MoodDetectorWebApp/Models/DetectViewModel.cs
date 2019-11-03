using Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace MoodDetectorWebApp.Models
{
    public class DetectViewModel
    {
        public User User { get; set; }
        public DateTime DateTime { get; set; }
        public int MessageSeen { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string Class { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Subject { get; set; }

        public string Comments { get; set; }
    }
}