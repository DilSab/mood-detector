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
        public LearningsController(IMoodService moodService)
        {
            _moodService = moodService;
        }

        // GET: Learnings
        public ActionResult LearningsIndex()
        {
            return View();
        }
        public ActionResult GetLearnings(int id)
        {
            
            LearningService learningService = new LearningService(new User() { Id = id }, _moodService);
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