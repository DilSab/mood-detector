namespace Model
{
    public class LearningMessage
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Session session { get; set; }
        public int Mask { get; set; }
        public string Link { get; set; }
        public int SessionTime { get; set; }
        public string EmotionName { get; set; }
    }
}
