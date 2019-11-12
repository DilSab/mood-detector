using Model;
using System.Data.Entity.Validation;
using System.Diagnostics;

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

            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var errors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in errors.ValidationErrors)
                    {
                        // get the error message 
                        Debug.Write(validationError.ErrorMessage);
                    }
                }
            }

            return 1;
        }
    }
}
