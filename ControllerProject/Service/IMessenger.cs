using Model;

namespace ControllerProject.Service
{
    public interface IMessenger
    {
        event Messenger.MessagePostedEventHandler MessagePosted;

        void PostMessage(GlobalMessage message);
    }
}