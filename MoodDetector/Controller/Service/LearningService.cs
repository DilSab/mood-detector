using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Tuple<string, int> GetAngerMessage()
        {
            Mood mood = _moodService.GetLastClassMood(user);
            if (mood.Anger >= 0.8) return new Tuple<string, int>("", mood.ClassMoodId);
            string mess = "Anger levels are too high in your classes! You have a learning assigned";
            return new Tuple<string, int>(mess, mood.ClassMoodId);
        }

        public Tuple<string, int> GetJoyMessage()
        {
            Mood mood = _moodService.GetLastClassMood(user);
            if (mood.Joy < 0.8) return new Tuple<string, int>("", mood.ClassMoodId);
            string mess = "Joy levels are too low in your classes! You have a learning assigned";
            return new Tuple<string, int>(mess, mood.ClassMoodId);
        }
    }
}
