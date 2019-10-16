using Model;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Diagnostics;

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
                    Comments = addMood.SessionInfo.Comments,
                    MessageSeen = addMood.SessionInfo.MessageSeen
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

        public Mood GetLastClassMood(User user, int mask)
        {
            Mood mood = new Mood();
            mood.Anger = 0;
            mood.Joy = 1;
            if (!_context.ClassMoods.Any()) return mood;
            IQueryable<ClassMood> classMoods = (from m in _context.ClassMoods
                                                where m.UserId == user.Id
                                                select m);
            if (!classMoods.Any()) return mood;
            ClassMood classmood = classMoods.OrderByDescending(x => x.Id).First();
            if (GetSessionMessageStatus(classmood.Id, mask) > 0) return mood;
            MoodCollection moodCollection = GetMoodAverage(classmood.Moods.ToList());
            mood = _context.Moods.First(x => x.ClassMoodId == classmood.Id);
            mood.Anger = moodCollection.Anger;
            mood.Joy = moodCollection.Joy;
            //Debug.WriteLine("anger " + mood.Anger+" joy "+mood.Joy);
            return mood;
        }

        public void UpdateSessionMessageStatus(int classmoodId, int mask)
        {

            var classmood = _context.ClassMoods.First(x => x.Id == classmoodId);
            classmood.MessageSeen |= mask;            
            _context.Entry(classmood).State = EntityState.Modified;
            _context.SaveChanges();
        }

        private int GetSessionMessageStatus(int classmoodId, int mask)
        {
            ClassMood classmood = _context.ClassMoods.First(x => x.Id == classmoodId);
            return classmood.MessageSeen & mask;
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
