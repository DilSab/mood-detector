using Model;

namespace ControllerProject.Service
{
    public interface IMessageManager
    {
        int AddGlobalMessage(GlobalMessage message);
    }
}