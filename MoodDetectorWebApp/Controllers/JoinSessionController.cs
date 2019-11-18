using System.Web.Mvc;
using ControllerProject.Service;
using MoodDetectorWebApp.Models;
using System;
using Model.Entity;
using Model;

namespace MoodDetectorWebApp.Controllers
{
    public class JoinSessionController : Controller
    {
            private IMoodService _moodService;
            private IUserService _userService;

            public JoinSessionController(IMoodService moodService, IUserService userService)
            {
                _moodService = moodService;
                _userService = userService;
            }
      
        
           // GET: JoinSession
           public ActionResult JoinSession ()
           {
               return View(new JoinSessionModel());
           }

           
           // POST: JoinSession
           [HttpPost]
           public ActionResult JoinSession(JoinSessionModel model)
           {

            // Link with database
            
            if (ModelState.IsValid)
            {
                return View("~/Views/JoinSession/Session.cshtml", model);
            }
            return View();
           }          
    }
}