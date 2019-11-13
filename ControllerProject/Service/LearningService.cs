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

        private Message GetMessage(Mood mood, string text, int mask)
        {
            return new Message()
            {
                Text = text,
                SessionId = mood.SessionId,
                Mask = mask,
                SessionTime = mood.Session.DateTime.AddDays(7).Ticks
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
        private Message GetEmotionMessage(string emotion, int mask)
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

        public List<Message> GetMessages()
        {
            List<Message> messages = new List<Message>();
            messages.Add(GetEmotionMessage("Anger",1));
            messages.Add(GetEmotionMessage("Disgust",4));
            messages.Add(GetEmotionMessage("Fear",8));
            messages.Add(GetEmotionMessage("Sadness",16));
            return messages;

        }
    }
}
