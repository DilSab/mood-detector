using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerProject.Service
{
    public interface ILearningService
    {
        List<LearningMessage> GetMessages(User user);
        List<Learning> GetLearnings();
        void EditLearning(Learning editLearning, int id);
        Learning getLearningWithId(int id);
        List<LearningsLate> getLateLearnings();
        void AddFeedback(Feedback feedback);
        int GetLatestMessage(User user);
        List<Feedback> GetFeedbacks();
    }
}
