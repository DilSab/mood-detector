using System;

namespace MoodDetectorWebApp.Models
{
    public class SessionSummary
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string studentClass { get; set; }
        public string subject { get; set; }
        public string comment { get; set; }
        public string emoji { get; set; }
    }
}