using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Model;

namespace ControllerProject.Service
{
    public class LearningService : ILearningService
    {
        private User user;
        private IMoodService _moodService;
        private MoodDetectorDbContext _context;
        private IUserService _userService;

        public LearningService(IMoodService moodService, IUserService userService, MoodDetectorDbContext context)
        {
            _moodService = moodService;
            _userService = userService;
            _context = context;
        }
        private LearningMessage GetMessage(Mood mood, string text, Learning learning)
        {
            return new LearningMessage()
            {
                Text = text,
                session = mood.Session,
                Mask = learning.Mask,
                SessionTime = mood.Session.DateTime.AddDays(7).Subtract(DateTime.Now).Days,
                Link = learning.Link,
                EmotionName = learning.EmotionName
            };
        }
        private double GetEmotionValue(Mood mood, Learning learning)
        {
            if (learning.EmotionName == "Anger") return mood.Anger;
            if (learning.EmotionName == "Disgust") return mood.Disgust;
            if (learning.EmotionName == "Fear") return mood.Fear;
            if (learning.EmotionName == "Sadness") return mood.Sadness;
            return -1;
        }

        private LearningMessage GetEmotionMessage(Learning learning)
        {
            Mood mood = _moodService.GetLastClassMood(user, learning.Mask);
            double emotionValue = GetEmotionValue(mood, learning);
            if (emotionValue < 0.02)
            {
                if (mood.Session.Id != -1 && _moodService.GetSessionMessageStatus(mood.Session.Id, learning.Mask) == 0)
                {
                    _moodService.UpdateSessionMessageStatus(mood.Session.Id, learning.Mask);
                    return GetEmotionMessage(learning);
                }
                return GetMessage(mood, "", learning);
            }

            return GetMessage(mood, learning.Text, learning);
        }

        public List<Learning> GetLearnings()
        {
            return _context.Learnings.ToList();
        }
        public Learning getLearningWithId(int id)
        {
            return (from l in _context.Learnings
                    where l.Id == id
                    select l).FirstOrDefault(); 
        }
        public void EditLearning(Learning editLearning, int id)
        {
            var learning = (from l in _context.Learnings
                               where l.Id == id
                               select l).FirstOrDefault();

            learning.Text = editLearning.Text;
            learning.Link = editLearning.Link;

            _context.SaveChanges();
        }

        public List<LearningsLate> getLateLearnings()
        {
            List<User> users = _userService.GetUsers();
            List<LearningsLate> learningsLates = new List<LearningsLate>();
            foreach(User i in users)
            {
                List<LearningMessage> messages = GetMessages(i);
                foreach(LearningMessage j in messages)
                {
                    if (j.SessionTime < 0)
                    {
                        learningsLates.Add(new LearningsLate()
                        {
                            Teacher = i,
                            Days = -j.SessionTime,
                            EmotionName = j.EmotionName
                        });
                    }

                }
            }
            return learningsLates;
        }
        public int GetLatestMessage(User user)
        {
            var messages = GetMessages(user);
            return messages.Any() ? messages.Min(m => m.SessionTime) : int.MaxValue;
        }
        public void AddFeedback(Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
            _context.SaveChanges();
        }
        public List<Feedback> GetFeedbacks()
        {
            return _context.Feedbacks.ToList();
        }

        public List<LearningMessage> GetMessages(User user)
        {
            this.user = user;
            List<LearningMessage> messages = new List<LearningMessage>();
            List<Learning> learnings = GetLearnings();
            foreach(Learning i in learnings)
            {
                LearningMessage learningMessage = GetEmotionMessage(i);
                if(learningMessage.Text!="")messages.Add(learningMessage);
            }
            return messages;

        }
    }
}
