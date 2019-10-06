using Model;
using Model.Entity;

namespace Controller.Service
{
    public class MoodService : IMoodService
    {
        public void AddClassMood(AddMood addMood)
        {
            using (var context = new MoodDetectorDBEntities())
            {
                var mood = new Mood()
                {
                    ClassMood = new ClassMood()
                    {
                        UserId = addMood.SessionInfo.User.Id,
                        Subject = addMood.SessionInfo.Subject,
                        Class = addMood.SessionInfo.Class,
                        DateTime = addMood.SessionInfo.DateTime,
                        Comments = addMood.SessionInfo.Comments
                    },
                    Anger = addMood.MoodCollection.Anger,
                    Joy = addMood.MoodCollection.Joy,
                    Contempt = addMood.MoodCollection.Contempt,
                    Disgust = addMood.MoodCollection.Disgust,
                    Engagement = addMood.MoodCollection.Engagement,
                    Fear = addMood.MoodCollection.Fear,
                    Sadness = addMood.MoodCollection.Sadness,
                    Suprise = addMood.MoodCollection.Suprise,
                    Valence = addMood.MoodCollection.Valence,
                };
                context.Moods.Add(mood);
                context.SaveChanges();
            }
        }
    }
}
