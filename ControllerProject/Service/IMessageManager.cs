using Model;
using System.Collections.Generic;

namespace ControllerProject.Service
{
    public interface IMessageManager
    {
        int AddGlobalMessage(GlobalMessage message);
        int GetGlobalMessageCountByUser(User user);
        int GetGlobalMessageRecipientsAllCount();
        int DeleteGlobalMessageById(int id);
        List<GlobalMessage> GetRecipientGlobalMessages(User user);
        List<GlobalMessage> GetRecipientsAllGlobalMessages();
    }
}