using ControllerProject.Service;
using System.Collections.Generic;
using System.Web.Mvc;
using Model;
using Model.Entity;
using MoodDetectorWebApp.Models;
using System;
using Newtonsoft.Json;

namespace MoodDetectorWebApp.Controllers
{
    public class SessionController : Controller
    {
        IMoodService _moodService;
        IUserService _userService;

        public SessionController(IMoodService moodService, IUserService userService)
        {
            _moodService = moodService;
            _userService = userService;
        }

        public ActionResult Session()
        {
            return View();
        }

        //NEW SESSION

        // GET: Detector
        [HttpGet]
        public ActionResult NewSession()
        {
            return View(new NewSessionModel());
        }

        // POST: Detector
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewSession(NewSessionModel model)
        {
            // Randamas dabartinis vartotojas is prisijungimo metu sukurto cookio.
            User currentUser = _userService.GetUser(System.Web.HttpContext.Current.User.Identity.Name);

            if (ModelState.IsValid)
            {
                SessionInfo sessionInfo = new SessionInfo()
                {
                    User = currentUser,
                    Class = model.Class,
                    Comments = model.Comments,
                    Subject = model.Subject,
                    DateTime = DateTime.Now,
                    MessageSeen = 0,
                };

                int detectionId = _moodService.AddSession(sessionInfo);
                DetectionStartViewModel detectionStartViewModel = new DetectionStartViewModel()
                {
                    DetectionId = detectionId,
                };

                return View("~/Views/Detector/Start.cshtml", detectionStartViewModel);
            }

            return View();
        }

        // POST: Detector/PostMoods/
        public void PostMoods(int detectionId, string moods)
        {
            _moodService.AddMood(detectionId, JsonConvert.DeserializeObject<MoodCollection>(moods));
        }

        //EXISTING SESSIONS

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
    }
}