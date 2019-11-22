using ControllerProject.Service;

namespace ControllerProject.Logger
{
    public interface IMessageLogger
    {
        void Log(string message);
        void OnMessagePosted(object source, MessagePostedEventArgs args);
    }
}