using System.Collections.Generic;

namespace Model
{
    public class Session
    {
        public Session()
        {
            this.Moods = new HashSet<Mood>();
            this.JoinSessions = new HashSet<JoinSession>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Subject { get; set; }
        public string Class { get; set; }
        public System.DateTime DateTime { get; set; }
        public string Comments { get; set; }
        public int MessageSeen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mood> Moods { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JoinSession> JoinSessions { get; set; }
    }
}
