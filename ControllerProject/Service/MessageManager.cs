using Model;

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
    }
}
