using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Entity;
namespace ControllerProject.Service
{
    public interface IRegisterAuthenticator
    {
        bool IsRegisterDataCorrect(UserWithLogin addUser);
    }
}
