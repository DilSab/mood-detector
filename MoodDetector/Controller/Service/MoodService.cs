using Model;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Controller.Service
{
    public class MoodService : IMoodService
    {
        private MoodDetectorDBEntities _context;

        public MoodService(MoodDetectorDBEntities context)
        {
            _context = context;
        }

        public void AddClassMood(AddMood addMood)
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
            _context.Moods.Add(mood);
            _context.SaveChanges();
        }

        public List<Mood> GetMoodsByDate(User user, DateTime? dateTime = null)
        {
            List<int> classMoodIds;

            if (dateTime != null)
            {
                var date = dateTime.Value.Date;
                classMoodIds = (from c in _context.ClassMoods
                                where TruncateTime(c.DateTime) == date
                                && c.UserId == user.Id
                                select c.Id).ToList();
            }
            else
            {
                classMoodIds = (from c in _context.ClassMoods
                                where c.UserId == user.Id
                                select c.Id).ToList();
            }

            if (classMoodIds.Any())
            {
                List<Mood> moods = (from m in _context.Moods
                                    where classMoodIds.Contains(m.ClassMoodId)
                                    select m).ToList();

                return moods;
            }

            return null;
        }

        public Mood GetLastClassMood(User user)
        {
            Mood mood = new Mood();
            mood.Anger = 0;
            mood.Joy = 1;
            if (GetSessionMessageStatus(user)) return mood;

            // needs update for real last class mood
            Random rng = new Random();
            mood.Anger = rng.NextDouble();
            mood.Joy = rng.NextDouble();
            return mood;
        }

        public void UpdateSessionMessageStatus(int classmoodId)
        {
            // needs to be implemented (set true)
        }
        private bool GetSessionMessageStatus(User user)
        {
            // needs to be implemented
            return false;
        }

        [DbFunction("Edm", "TruncateTime")]
        private DateTime? TruncateTime(DateTime? dateValue)
        {
            return dateValue?.Date;
        }

        public MoodCollection GetMoodAverage(List<Mood> moods)
        {
            return new MoodCollection()
            {
                Anger = moods.Average(emotion => emotion.Anger),
                Contempt = moods.Average(emotion => emotion.Contempt),
                Disgust = moods.Average(emotion => emotion.Disgust),
                Engagement = moods.Average(emotion => emotion.Engagement),
                Fear = moods.Average(emotion => emotion.Fear),
                Joy = moods.Average(emotion => emotion.Joy),
                Sadness = moods.Average(emotion => emotion.Sadness),
                Suprise = moods.Average(emotion => emotion.Suprise),
                Valence = moods.Average(emotion => emotion.Valence)
            };
        }
    }
}
