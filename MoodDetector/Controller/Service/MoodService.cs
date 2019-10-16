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

        public int AddSession(SessionInfo sessionInfo)
        {
            var session = new Session()
            {
                UserId = sessionInfo.User.Id,
                Subject = sessionInfo.Subject,
                Class = sessionInfo.Class,
                DateTime = sessionInfo.DateTime,
                Comments = sessionInfo.Comments,
                MessageSeen = sessionInfo.MessageSeen
            };

            _context.Sessions.Add(session);
            _context.SaveChanges();

            return session.Id;
        }

        public void AddMood(int sessionId, MoodCollection moodCollection)
        {
            var mood = new Mood()
            {
                SessionId = sessionId,
                Anger = moodCollection.Anger,
                Joy = moodCollection.Joy,
                Contempt = moodCollection.Contempt,
                Disgust = moodCollection.Disgust,
                Engagement = moodCollection.Engagement,
                Fear = moodCollection.Fear,
                Sadness = moodCollection.Sadness,
                Suprise = moodCollection.Suprise,
                Valence = moodCollection.Valence,
            };

            _context.Moods.Add(mood);
            _context.SaveChanges();
        }


        public List<Mood> GetMoodsByDate(User user, DateTime? dateTime = null)
        {
            List<int> sessionIds;

            if (dateTime != null)
            {
                var date = dateTime.Value.Date;
                sessionIds = (from c in _context.Sessions
                                where TruncateTime(c.DateTime) == date
                                && c.UserId == user.Id
                                select c.Id).ToList();
            }
            else
            {
                sessionIds = (from c in _context.Sessions
                                where c.UserId == user.Id
                                select c.Id).ToList();
            }

            if (sessionIds.Any())
            {
                List<Mood> moods = (from m in _context.Moods
                                    where sessionIds.Contains(m.SessionId)
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
            if (!_context.Sessions.Any()) return mood;
            IQueryable<Session> sessions = (from m in _context.Sessions
                                                where m.UserId == user.Id
                                                select m);

            if (!sessions.Any()) return mood;

            Session session = sessions.OrderByDescending(x => x.Id).First();
            if (GetSessionMessageStatus(session.Id, mask) > 0) return mood;

            MoodCollection moodCollection = GetMoodAverage(session.Moods.ToList());
            mood = _context.Moods.First(x => x.SessionId == session.Id);
            mood.Anger = moodCollection.Anger;
            mood.Joy = moodCollection.Joy;

            return mood;
        }

        public void UpdateSessionMessageStatus(int classmoodId, int mask)
        {
            var classmood = _context.Sessions.First(x => x.Id == classmoodId);
            classmood.MessageSeen |= mask;   
            
            _context.Entry(classmood).State = EntityState.Modified;
            _context.SaveChanges();
        }

        private int GetSessionMessageStatus(int classmoodId, int mask)
        {
            Session session = _context.Sessions.First(x => x.Id == classmoodId);

            return session.MessageSeen & mask;
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
