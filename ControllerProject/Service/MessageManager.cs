using Model;
using System.Collections.Generic;
using System.Linq;

namespace ControllerProject.Service
{
    public class MessageManager : IMessageManager
    {
        private MoodDetectorDBEntities _context;

        public MessageManager(MoodDetectorDBEntities context)
        {
            _context = context;
        }

        public int AddGlobalMessage(GlobalMessage message)
        {
            _context.GlobalMessages.Add(message);

            return _context.SaveChanges();
        }

        public List<GlobalMessage> GetGlobalMessagesByUser(User user)
        {
            var globalMessages = (from g in _context.GlobalMessages
                                  where g.UserId == user.Id
                                  select g).ToList();

            return globalMessages;
        }

        public int DeleteGlobalMessageById(int id)
        {
            var globalMessage = (from g in _context.GlobalMessages
                                 where g.Id == id
                                 select g).FirstOrDefault();

            _context.GlobalMessages.Remove(globalMessage);

            return _context.SaveChanges();
        }

        public List<GlobalMessage> GetRecipientGlobalMessages(User user)
        {
            var globalMessages = (from g in _context.GlobalMessages
                                  where (g.RecipientType == user.AccessRights
                                     || g.RecipientType == "All")
                                  && g.UserId != user.Id
                                  select g).ToList();

            return globalMessages;
        }
    }
}
