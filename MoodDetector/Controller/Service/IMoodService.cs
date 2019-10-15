using Model;
using Model.Entity;
using System;
using System.Collections.Generic;

namespace Controller.Service
{
    public interface IMoodService
    {
        void AddClassMood(AddMood addMood);
        List<Mood> GetMoodsByDate(User user, DateTime? dateTime = null);
        Mood GetLastClassMood(User user, int mask);
        void UpdateSessionMessageStatus(int classmoodId, int mask);
        MoodCollection GetMoodAverage(List<Mood> moods);
    }
}
