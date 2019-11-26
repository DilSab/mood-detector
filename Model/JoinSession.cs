

namespace Model
{
    public class JoinSession
    {

        public int Id { get; set; }
        public int SessionId { get; set; }
        public string JoinName { get; set; }

        public virtual Session Session { get; set; }
    }
}
