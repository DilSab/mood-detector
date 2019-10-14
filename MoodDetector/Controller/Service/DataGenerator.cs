using Model.Entity;
using System;

namespace Controller.Service
{
    public class DataGenerator : IDataGenerator
    {
        public MoodCollection GetRandomMoodCollection()
        {
            MoodCollection moodCollection = new MoodCollection
            {
                Anger = RandomDouble(0.0, 100.0),
                Contempt = RandomDouble(0.0, 100.0),
                Disgust = RandomDouble(0.0, 100.0),
                Engagement = RandomDouble(0.0, 100.0),
                Fear = RandomDouble(0.0, 100.0),
                Joy = RandomDouble(0.0, 100.0),
                Sadness = RandomDouble(0.0, 100.0),
                Suprise = RandomDouble(0.0, 100.0),
                Valence = RandomDouble(0.0, 100.0),
            };

            return moodCollection;
        }

        private double RandomDouble(double from, double to)
        {
            var random = new Random(Guid.NewGuid().GetHashCode());
            var difference = Math.Abs(from - to);

            return random.NextDouble() * difference + from;
        }
    }
}
