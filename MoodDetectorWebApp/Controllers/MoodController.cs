using ControllerProject.Service;
using System.Collections.Generic;
using System.Web.Mvc;
using Model;
using Model.Entity;
using MoodDetectorWebApp.Models;
using System;

namespace MoodDetectorWebApp.Controllers
{
    [Authorize(Roles = "teacher")]
    public class MoodController : Controller
    {
        IMoodService _moodService;
        IUserService _userService;

        public MoodController(IMoodService moodService, IUserService userService)
        {
            _moodService = moodService;
            _userService = userService;
        }

        public ActionResult MoodIndex()
        {
            return View();
        }

        public ActionResult SessionIndex()
        {
            return View("SessionIndex");
        }

        public ActionResult SessionsList()
        {
            int userId = _userService.GetUser(System.Web.HttpContext.Current.User.Identity.Name).Id;
            List<SessionSummary> sessions = new List<SessionSummary>();
            List<int> sessionsIds = _moodService.GetAllSessionsIds(userId);
            foreach (int id in sessionsIds)
            {
                Session session = _moodService.GetSession(id);
                SessionSummary sessionSummary = new SessionSummary
                {
                    id = id,
                    date = session.DateTime,
                    studentClass = session.Class,
                    subject = session.Subject,
                    comment = session.Comments
                };
                sessions.Add(sessionSummary);
            }
            return View("SessionsList", sessions);
        }

        public ActionResult GetMoodList(int id)
        {
            List<Mood> moods = _moodService.GetMoodsByDate(new User() { Id = id });
            
            return View("MoodList", moods);
        }

        public ActionResult GetSessionMoodAverage(int id)
        {
            try
            {
                MoodCollection mood = _moodService.GetMoodsBySessionId(id);
                Dictionary<string, double> dominantMoods = _moodService.GetDominantMoods(mood);
                return View("SessionMood", dominantMoods);
            }
            catch (ArgumentException ex)
            {
                return View("ErrorMessage", model: ex.Message);
            }
        }

        public ActionResult RedirectToJoinSessionList (int id)
        {            
            return RedirectToAction("JoinSessionList", "JoinSession", new { sessionId = id });           
        }
    }
}
