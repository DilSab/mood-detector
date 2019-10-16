using Model;
using Model.Entity;
using System;
using System.Collections.Generic;

namespace Controller.Service
{
    public interface IMoodService
    {
        int AddSession(SessionInfo sessionInfo);
        void AddMood(int sessionId, MoodCollection moodCollection);
        List<Mood> GetMoodsByDate(User user, DateTime? dateTime = null);
        Mood GetLastClassMood(User user, int mask);
        void UpdateSessionMessageStatus(int classmoodId, int mask);
        MoodCollection GetMoodAverage(List<Mood> moods);
    }
}
