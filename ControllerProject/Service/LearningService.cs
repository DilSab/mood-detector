using System;
using System.Collections.Generic;
using System.Diagnostics;
using Model;

namespace ControllerProject.Service
{
    public class LearningService : ILearningService
    {
        private User user;
        private IMoodService _moodService;

        public LearningService(User user, IMoodService moodService)
        {
            this.user = user;
            _moodService = moodService;
        }
        private string GetLinkValue(int mask)
        {
            if (mask == 1) return "https://blog.brookespublishing.com/8-anger-management-tips-for-your-students/";
            if (mask == 4) return "https://www.psychologytoday.com/us/blog/smell-life/201202/taking-control-disgust";
            if (mask == 8) return "https://www.facultyfocus.com/articles/teaching-and-learning/strategies-for-addressing-student-fear-in-the-classroom/";
            if (mask == 16) return "https://www.wikihow.com/Overcome-Sadness";
            return "";
        }
        private LearningMessage GetMessage(Mood mood, string text, int mask)
        {
            return new LearningMessage()
            {
                Text = text,
                SessionId = mood.SessionId,
                Mask = mask,
                SessionTime = mood.Session.DateTime.AddDays(7).Ticks,
                Link = GetLinkValue(mask)
            };
        }
        private double GetEmotionValue(Mood mood, int mask)
        {
            if (mask == 1) return mood.Anger;
            if (mask == 4) return mood.Disgust;
            if (mask == 8) return mood.Fear;
            if (mask == 16) return mood.Sadness;
            return -1;
        }

        private LearningMessage GetEmotionMessage(string emotion, int mask)
        {
            Mood mood = _moodService.GetLastClassMood(user, mask);
            double emotionValue = GetEmotionValue(mood, mask);
            if (emotionValue < 0.02)
            {
                if (mood.Session.Id != -1 && _moodService.GetSessionMessageStatus(mood.Session.Id, mask) == 0)
                {
                    _moodService.UpdateSessionMessageStatus(mood.Session.Id, mask);
                    return GetEmotionMessage(emotion, mask);
                }
                return GetMessage(mood, "", mask);
            }
            string mess = emotion+" levels are too high in your classes! You have a learning assigned";

            return GetMessage(mood, mess, mask);
        }

        public List<LearningMessage> GetMessages()
        {
            List<LearningMessage> messages = new List<LearningMessage>();
            messages.Add(GetEmotionMessage("Anger",1));
            messages.Add(GetEmotionMessage("Disgust",4));
            messages.Add(GetEmotionMessage("Fear",8));
            messages.Add(GetEmotionMessage("Sadness",16));
            return messages;

        }
    }
}
