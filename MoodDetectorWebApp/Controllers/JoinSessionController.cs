using System.Web.Mvc;
using System.Collections.Generic;
using ControllerProject.Service;
using MoodDetectorWebApp.Models;
using System;

using Model;


namespace MoodDetectorWebApp.Controllers
{
    public class JoinSessionController : Controller
    {
        private IMoodService _moodService;      
        private MoodDetectorDbContext _context;

        public JoinSessionController(IMoodService moodService, MoodDetectorDbContext context)
        {
            _moodService = moodService;            
            _context = context;
        }        
  
        public ActionResult JoinSessionConnect ()
        {
            return View(new JoinSessionModel());
        }       
 
        [HttpPost]
        public ActionResult JoinSessionConnect(JoinSessionModel model)
        {           
            if (ModelState.IsValid)
            {
                if (_moodService.GetSession(model.DetectionId) != null)
                {
                    JoinSession join = new JoinSession()
                    {
                        SessionId = model.DetectionId,
                        JoinName = model.JoinName,
                        DateTime = DateTime.Now,
                    };                        

                    _context.JoinSessions.Add(join);
                    _context.SaveChanges();

                    Session session = _moodService.GetSession(model.DetectionId);
                    model.VideoId = session.VideoId.Replace("https://www.youtube.com/watch?v=", "");
                    model.JoinSessionId = join.Id;                       
                  
                return View("~/Views/JoinSession/JoinSession.cshtml", model);
                }
            }

            return View();
        }

        public ActionResult JoinSessionList(int sessionId)
        {                        
            List<JoinSessionSummary> joinSessions = new List<JoinSessionSummary>();
            List<int> joinSessionsIds = _moodService.GetAllJoinSessionIds(sessionId);
            foreach (int id in joinSessionsIds)
            {
                JoinSession joinSession = _moodService.GetJoinSession(id);
                JoinSessionSummary joinSessionSummary = new JoinSessionSummary
                {
                    Id = id,
                    JoinName = joinSession.JoinName,
                    Date = joinSession.DateTime,
      
                };
                joinSessions.Add(joinSessionSummary);
            }
            return View("JoinSessionList", joinSessions);
        }

        public ActionResult GetJoinSessionDiagram(int id)
        {

            JoinSession joinSession = _moodService.GetJoinSession(id);
            JoinSessionSummary joinSessionSummary = new JoinSessionSummary
            {
                Id = id,
                JoinName = joinSession.JoinName,
                Date = joinSession.DateTime,
                SessionSVG = joinSession.JoinSessionSVG,
            };

            return View("JoinSessionDiagram", joinSessionSummary);           
        }
     
        public void AddSVG(int joinSessionId, string svg)
        {
            _moodService.AddSVGToJoinSession(joinSessionId, svg);            
        }
    }
}
