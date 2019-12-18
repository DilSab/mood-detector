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
        ILearningService _learningService;
        public LearningsController(IMoodService moodService, IUserService userService, ILearningService learningService)
        {
            _moodService = moodService;
            _userService = userService;
            _learningService = learningService;
        }

        // GET: Learnings
        public ActionResult Learnings()
        {
            User currentUser = _userService.GetUser(System.Web.HttpContext.Current.User.Identity.Name);
            List<LearningMessage> learnings = _learningService.GetMessages(currentUser);
            return View("Learnings",learnings);
        }
        public ActionResult RemoveLearning(int a, int b, string c)
        {
            _moodService.UpdateSessionMessageStatus(a, b);
            return View("Feedback",new FeedbackModel() { EmotionName = c });
        }
        public object LoadRecipientLearnings()
        {
            User user = _userService.GetUser(System.Web.HttpContext.Current.User.Identity.Name);
            if(user==null||user.AccessRights=="Admin") return Json(new { success = false }, JsonRequestBehavior.AllowGet);

            int learningsCount = _learningService.GetMessages(user).Count;

            return Json(new { success = true, count = learningsCount }, JsonRequestBehavior.AllowGet);
        }
        public object LoadPopUp()
        {
            User user = _userService.GetUser(System.Web.HttpContext.Current.User.Identity.Name);
            int minDays = _learningService.GetLatestMessage(user);
            return Json(new { success = true, count = minDays }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Feedback(FeedbackModel model, string emotion)
        {
            User currentUser = _userService.GetUser(System.Web.HttpContext.Current.User.Identity.Name);
            Debug.WriteLine(emotion);
            var feedback = new Feedback()
            {
                EmotionName = model.EmotionName,
                User = currentUser,
                Comments = model.Comments
            };
            _learningService.AddFeedback(feedback);

            return Learnings();
        }
    }
}