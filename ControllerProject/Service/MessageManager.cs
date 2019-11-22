using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControllerProject.Service
{
    public class MessageManager : IMessageManager
    {
        private MoodDetectorDbContext _context;

        public MessageManager(MoodDetectorDbContext context)
        {
            _context = context;
        }

        public int AddGlobalMessage(GlobalMessage message)
        {
            _context.GlobalMessages.Add(message);

            return _context.SaveChanges();
        }

        public int GetGlobalMessageCountByUser(User user)
        {
            int messageCount;
            if (user.AccessRights == "Admin")
            {
                messageCount = (from g in _context.GlobalMessages
                                select g).Count();
            }
            else
            {
                messageCount = (from g in _context.GlobalMessages
                                  where (g.RecipientType == user.AccessRights
                                     || g.RecipientType == "All")
                                  && (g.ExpirationDate != null && (g.ExpirationDate.Value > DateTime.Now)
                                      || (g.ExpirationDate == null))
                                  select g).Count();
            }

            return messageCount;
        }

        public int GetGlobalMessageRecipientsAllCount()
        {
            int messageCount = (from g in _context.GlobalMessages
                                where g.RecipientType == "All"
                                && (g.ExpirationDate != null && (g.ExpirationDate.Value > DateTime.Now)
                                      || (g.ExpirationDate == null))
                                select g).Count();

            return messageCount;
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
            List<GlobalMessage> globalMessages;
            if (user.AccessRights == "Admin")
            {
                globalMessages = (from g in _context.GlobalMessages
                                      select g).ToList();
            }
            else
            {
                globalMessages = (from g in _context.GlobalMessages
                                      where (g.RecipientType == user.AccessRights
                                         || g.RecipientType == "All")
                                      && (g.ExpirationDate != null && ( g.ExpirationDate.Value > DateTime.Now )
                                          || (g.ExpirationDate == null))
                                      select g).ToList();
            }

            return globalMessages;
        }

        public List<GlobalMessage> GetRecipientsAllGlobalMessages()
        {
            List<GlobalMessage> globalMessages = (from g in _context.GlobalMessages
                                                  where g.RecipientType == "All"
                                                  && (g.ExpirationDate != null && (g.ExpirationDate.Value > DateTime.Now)
                                                      || (g.ExpirationDate == null))
                                                  select g).ToList();

            return globalMessages;
        }
    }
}
