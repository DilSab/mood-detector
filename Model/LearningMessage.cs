namespace Model
{
    public class LearningMessage
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int SessionId { get; set; }
        public int Mask { get; set; }
        public string Link { get; set; }
        public long SessionTime { get; set; }
    }
}
