namespace Model
{
    public class Mood
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public double Anger { get; set; }
        public double Joy { get; set; }
        public double Contempt { get; set; }
        public double Disgust { get; set; }
        public double Engagement { get; set; }
        public double Fear { get; set; }
        public double Sadness { get; set; }
        public double Suprise { get; set; }
        public double Valence { get; set; }
        public string Emoji { get; set; }

        public virtual Session Session { get; set; }
    }
}
