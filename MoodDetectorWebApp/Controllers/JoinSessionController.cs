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
            private MoodDetectorDbContext _context;

            public JoinSessionController(IMoodService moodService, IUserService userService, MoodDetectorDbContext context)
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
                            SessionId = model.DetectionId,
                            JoinName = model.JoinName,
                        };                        

                        _context.JoinSessions.Add(join);
                        _context.SaveChanges();


                    return View("~/Views/JoinSession/Session.cshtml", model);
                    }
                }

                return View();
           }

        // POST: JoinSession/PostMoods/
        public void PostMoods(string moods)
        {
            System.Diagnostics.Debug.WriteLine("Atejo iki cia");            

            //int joinSessionId = 3002;
           // _moodService.AddMoodLive(joinSessionId, JsonConvert.DeserializeObject<MoodCollection>(moods));
        }
    }
}