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

        public List<Mood> GetMoodsByDate(User user, DateTime? dateTime = null)
        {
            using (var context = new MoodDetectorDBEntities())
            {
                List<int> classMoodIds;

                if (dateTime.HasValue)
                {
                    var date = dateTime.Value.Date;
                    classMoodIds = (from c in context.ClassMoods
                                        where DbFunctions.TruncateTime(c.DateTime) == date
                                        && c.UserId == user.Id
                                        select c.Id).ToList();
                }
                else
                {
                    classMoodIds = (from c in context.ClassMoods
                                        where c.UserId == user.Id
                                        select c.Id).ToList();
                }

                if (classMoodIds.Any())
                {
                    List<Mood> moods = (from m in context.Moods
                                        where classMoodIds.Contains(m.ClassMoodId)
                                        select m).ToList();

                    return moods;
                }

                return null;
            }
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
