using System.Collections.Generic;

namespace Model
{
    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string AccessRights { get; set; }

        public virtual ICollection<LoginInfo> LoginInfoes { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
        public virtual ICollection<GlobalMessage> GlobalMessages { get; set; }
    }
}
