using System;
using Model;

namespace Controller.Service
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
            if (mood.Anger < 0.8) return new Tuple<string, int, int>("", mood.ClassMoodId, 1);
            string mess = "Anger levels are too high in your classes! You have a learning assigned";
            return new Tuple<string, int, int>(mess, mood.ClassMoodId, 1);
        }

        public Tuple<string, int, int> GetJoyMessage()
        {
            Mood mood = _moodService.GetLastClassMood(user, 2);
            if (mood.Joy >= 0.8) return new Tuple<string, int, int>("", mood.ClassMoodId, 2);
            string mess = "Joy levels are too low in your classes! You have a learning assigned";
            return new Tuple<string, int, int>(mess, mood.ClassMoodId, 2);
        }
    }
}
