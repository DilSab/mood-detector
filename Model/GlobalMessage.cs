using System;

namespace Model
{
    public class GlobalMessage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string RecipientType { get; set; }

        public virtual User User { get; set; }
    }
}
