using ControllerProject.Service;
using Model;
using MoodDetectorWebApp.Models;
using System.Web.Mvc;
using System;

namespace MoodDetectorWebApp.Controllers
{
    public class LearningsAdminController : Controller
    {

        private ILearningService _learningService;

        public LearningsAdminController(ILearningService learningService)
        {
            _learningService = learningService;
        }

        [HttpGet]
        public ActionResult LearningsAdmin(LearningsModel learnings)
        {
            learnings.Learnings = _learningService.GetLearnings();

            return View("LearningsAdmin", learnings);
        }

        [HttpGet]
        public ActionResult EditLearning(int id)
        {
            var learning = _learningService.getLearningWithId(id);
            EditLearningModel editLearningModel = new EditLearningModel()
            {
                Link = learning.Link,
                Text = learning.Text
            };

            return View("EditLearning", editLearningModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditLearning(EditLearningModel editLearningModel, int id)
        {
            if (ModelState.IsValid)
            {
                Learning editLearning = new Learning()
                {
                    Link = editLearningModel.Link,
                    Text = editLearningModel.Text
                };
                _learningService.EditLearning(editLearning, id);

                return View("SuccessfulAdd");
            }

            return View("~/Views/LearningsAdmin/EditLearning.cshtml", id);
        }
        public ActionResult LateTeachers()
        {
            return View("LateTeachers", _learningService.getLateLearnings());
        }
        public ActionResult ShowFeedbacks()
        {
            return View("ShowFeedbacks", _learningService.GetFeedbacks());
        } 
    }
}