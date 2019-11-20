using ControllerProject.Service;
using Model;
using Model.Entity;
using MoodDetectorWebApp.Models;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace MoodDetectorWebApp.Controllers
{
    [Authorize(Roles = "teacher")]
    public class DetectorController : Controller
    {
        private IMoodService _moodService;
        private IUserService _userService;

        public DetectorController(IMoodService moodService, IUserService userService)
        {
            _moodService = moodService;
            _userService = userService;
        }

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

            if (ModelState.IsValid) {
                SessionInfo sessionInfo = new SessionInfo()
                {
                    User = currentUser,
                    Class = model.Class,
                    Comments = model.Comments,
                    Subject = model.Subject,
                    DateTime = DateTime.Now,
                    MessageSeen = 0,
                };

                int detectionId =_moodService.AddSession(sessionInfo);
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
    }
}