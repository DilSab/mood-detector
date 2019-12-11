using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class JoinSession
    {

        public int Id { get; set; }
        public int SessionId { get; set; }
        public string JoinName { get; set; }
        public System.DateTime DateTime { get; set; }
        [Column (TypeName = "text")]
        public string JoinSessionSVG { get; set; }

        public virtual Session Session { get; set; }
    }
}
