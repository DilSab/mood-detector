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
            List<Tuple<string, int, int>> learnings = new List<Tuple<string, int, int>>();
            LearningService learningService = new LearningService(new User() { Id = id }, _moodService);
            learnings.Add(learningService.GetJoyMessage());
            learnings.Add(learningService.GetAngerMessage());
            return View("Learnings",learnings);
        }
        public ActionResult RemoveLearning(int a, int b)
        {
            _moodService.UpdateSessionMessageStatus(a, b);
            Debug.WriteLine(a);
            return new EmptyResult();
        }
    }
}