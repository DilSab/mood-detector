using Model.Entity;

namespace ControllerProject.Service
{
    public interface IDataGenerator
    {
        MoodCollection GetRandomMoodCollection();
    }
}
