using Model.Entity;

namespace Controller.Service
{
    public interface IDataGenerator
    {
        MoodCollection GetRandomMoodCollection();
    }
}
