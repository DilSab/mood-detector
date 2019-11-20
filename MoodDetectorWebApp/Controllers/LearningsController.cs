using ControllerProject.Service;
using System.Web.Mvc;
using System.Collections.Generic;
using System;
using Model;
using MoodDetectorWebApp.Models;
using System.Diagnostics;

namespace MoodDetectorWebApp.Controllers
{
    public class LearningsController : Controller
    {
        IMoodService _moodService;
        IUserService _userService;
        public LearningsController(IMoodService moodService, IUserService userService)
        {
            _moodService = moodService;
            _userService = userService;
        }

        // GET: Learnings
        public ActionResult Learnings()
        {
            return GetLearnings();
        }
        public ActionResult GetLearnings()
        {
            User currentUser = _userService.GetUser(System.Web.HttpContext.Current.User.Identity.Name);
            LearningService learningService = new LearningService(new User() { Id = currentUser.Id }, _moodService);
            List<LearningMessage> learnings = learningService.GetMessages();
            return View("Learnings",learnings);
        }
        public ActionResult RemoveLearning(int a, int b)
        {
            _moodService.UpdateSessionMessageStatus(a, b);
            return new EmptyResult();
        }
    }
}