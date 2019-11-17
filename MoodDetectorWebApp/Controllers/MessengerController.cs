using ControllerProject.Service;
using Model;
using MoodDetectorWebApp.Models;
using System;
using System.Web.Mvc;
using System.Web.Services;

namespace MoodDetectorWebApp.Controllers
{
    public class MessengerController : Controller
    {
        private IMessageManager _messageManager;

        public MessengerController(IMessageManager messageManager)
        {
            _messageManager = messageManager;
        }

        // GET: Message
        public ActionResult Index()
        {
            return View();
        }

        // GET: Detector
        [HttpGet]
        public ActionResult GlobalMessage()
        {
            return View(new GlobalMessageModel());
        }

        public ActionResult LoadUserGlobalMessages()
        {
            var globalMessages = _messageManager.GetGlobalMessagesByUser(new User() { Id = 1 });

            return PartialView("~/Views/Messenger/Sidebar.cshtml", globalMessages);
        }

        public object LoadRecipientGlobalMessages()
        {
            var globalMessages = _messageManager.GetRecipientGlobalMessages(new User() { Id = 3 });

            return Json(new { success = true, count = globalMessages.Count }, JsonRequestBehavior.AllowGet); ;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGlobalMessage(int id)
        {
            _messageManager.DeleteGlobalMessageById(id);

            return RedirectToAction("GlobalMessage");
        }


        // POST: Detector
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostGlobalMessage(GlobalMessageModel model)
        {
            if (ModelState.IsValid)
            {
                GlobalMessage message = new GlobalMessage()
                {
                    Title = model.Title,
                    PostedDate = DateTime.Now,
                    UserId = 1,
                    Content = model.Content,
                    ExpirationDate = model.ExpirationDate,
                    RecipientType = model.RecipientType
                };

                _messageManager.AddGlobalMessage(message);
            }

            return RedirectToAction("GlobalMessage");
        }
    }
}