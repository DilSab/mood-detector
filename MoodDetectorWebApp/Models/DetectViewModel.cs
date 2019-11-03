using Model;
using System;

namespace MoodDetectorWebApp.Models
{
    public class DetectViewModel
    {
        public User User { get; set; }
        public string Class { get; set; }
        public string Subject { get; set; }
        public string Comments { get; set; }
        public DateTime DateTime { get; set; }
        public int MessageSeen { get; set; }
    }
}