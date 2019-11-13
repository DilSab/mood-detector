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
        List<Message> GetMessages();
    }
}
