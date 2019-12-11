using System.Data.Entity;

namespace Model
{
    public class MoodDetectorDbContext : DbContext
    {
        public MoodDetectorDbContext() : base("MoodDetectorDB")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<LoginInfo> LoginInfoes { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<JoinSession> JoinSessions { get; set; }
        public virtual DbSet<Mood> Moods { get; set; }
        public virtual DbSet<GlobalMessage> GlobalMessages { get; set; }
        public virtual DbSet<LearningMessage> LearningMessages { get; set; }
        public virtual DbSet<Learning> Learnings { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
