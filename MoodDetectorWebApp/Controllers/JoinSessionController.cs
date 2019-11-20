using System.Web.Mvc;
using ControllerProject.Service;
using MoodDetectorWebApp.Models;
using System;
using Model.Entity;
using Model;
using Newtonsoft.Json;

namespace MoodDetectorWebApp.Controllers
{
    public class JoinSessionController : Controller
    {
            private IMoodService _moodService;
            private IUserService _userService;
            private MoodDetectorDBEntities _context;

            public JoinSessionController(IMoodService moodService, IUserService userService, MoodDetectorDBEntities context)
                {
                    _moodService = moodService;
                    _userService = userService;
                    _context = context;
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
                if (ModelState.IsValid)
                {
                    if (_moodService.GetSession(model.DetectionId) != null)
                    {

                        JoinSession join = new JoinSession()
                        {
                            JoinSessionId = model.DetectionId,
                            JoinId = model.JoinId,
                        };

                        int joinSessionId = join.JoinSessionId;

                        _context.JoinSessions.Add(join);
                        _context.SaveChanges();


                    return View("~/Views/JoinSession/Session.cshtml", model);
                    }
                }

                return View();
           }

        // POST: Detector/PostMoods/
        public void PostMoods(int joinSessionId, string moods)
        {
            _moodService.AddMoodLive(joinSessionId, JsonConvert.DeserializeObject<MoodCollection>(moods));
        }
    }
}