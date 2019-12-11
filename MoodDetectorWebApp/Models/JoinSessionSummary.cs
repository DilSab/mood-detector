using System;

namespace MoodDetectorWebApp.Models
{
    public class JoinSessionSummary
    {
        public int Id { get; set; }
        public string JoinName { get; set; }
        public DateTime Date { get; set; }
        public string SessionSVG { get; set;}
    }
}