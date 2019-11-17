using Model;
using System.Collections.Generic;

namespace ControllerProject.Service
{
    public interface IMessageManager
    {
        int AddGlobalMessage(GlobalMessage message);
        List<GlobalMessage> GetGlobalMessagesByUser(User user);
        int DeleteGlobalMessageById(int id);
        List<GlobalMessage> GetRecipientGlobalMessages(User user);
    }
}