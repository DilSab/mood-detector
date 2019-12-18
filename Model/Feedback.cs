namespace Model
{
    public class Feedback
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public string EmotionName { get; set; }
        public string Comments { get; set; }
    }
}
