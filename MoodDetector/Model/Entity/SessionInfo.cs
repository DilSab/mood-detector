using System;

namespace Model.Entity
{
    public struct SessionInfo
    {
        public User User { get; set; }
        public string Class { get; set; }
        public string Subject { get; set; }
        public string Comments { get; set; }
        public DateTime DateTime { get; set; }
    }
}
