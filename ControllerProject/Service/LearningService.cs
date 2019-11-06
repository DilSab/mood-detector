using System;
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

        public Tuple<string, int, int> GetAngerMessage()
        {
            Mood mood = _moodService.GetLastClassMood(user, 1);
            if (mood.Anger < 0.02) return new Tuple<string, int, int>("", mood.SessionId, 1);
            string mess = "Anger levels are too high in your classes! You have a learning assigned";
            return new Tuple<string, int, int>(mess, mood.SessionId, 1);
        }

        public Tuple<string, int, int> GetJoyMessage()
        {
            Mood mood = _moodService.GetLastClassMood(user, 2);
            if (mood.Joy >= 0.8) return new Tuple<string, int, int>("", mood.SessionId, 2);
            string mess = "Joy levels are too low in your classes! You have a learning assigned";
            return new Tuple<string, int, int>(mess, mood.SessionId, 2);
        }
    }
}
