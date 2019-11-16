using ControllerProject.Service;
using System.Collections.Generic;
using System.Web.Mvc;
using Model;
using Model.Entity;

namespace MoodDetectorWebApp.Controllers
{
    public class MoodController : Controller
    {
        IMoodService _moodService;

        public MoodController(IMoodService moodService)
        {
            _moodService = moodService;
        }

        public ActionResult MoodIndex()
        {
            return View();
        }

        public ActionResult SessionIndex()
        {
            return View("SessionIndex");
        }

        public ActionResult GetMoodList(int id)
        {
            List<Mood> moods = _moodService.GetMoodsByDate(new User() { Id = id });
            
            return View("MoodList", moods);
        }

        public ActionResult GetSessionMoodAverage(int id)
        {
            MoodCollection mood = _moodService.GetMoodsBySessionId(id);
            Dictionary<string, double> dominantMoods = _moodService.GetDominantMoods(mood);
            return View("SessionMood", dominantMoods);
        }
    }
}
