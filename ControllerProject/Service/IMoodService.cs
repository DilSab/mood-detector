using Model;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControllerProject.Service
{
    public interface IMoodService
    {
        int AddSession(SessionInfo sessionInfo);
        void AddMood(int sessionId, MoodCollection moodCollection);
        void AddMoodLive(int joinSessionId, MoodCollection moodCollection);
        MoodCollection GetMoodsBySessionId(int id);
        List<int> GetAllSessionsIds(int userId);
        Session GetSession(int id);
        Dictionary<string, double> GetDominantMoods(MoodCollection moodCollection);
        List<Mood> GetMoodsByDate(User user, DateTime? dateTime = null);
        Mood GetLastClassMood(User user, int mask);
        void UpdateSessionMessageStatus(int classmoodId, int mask);
        MoodCollection GetMoodAverage(List<Mood> moods);
        string GetAverageEmoji(MoodCollection moodCollection);
    }
}
