using ControllerProject.Service;
using Model;
using MoodDetectorWebApp.Models;
using System;
using System.Web.Mvc;

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

        // POST: Detector
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GlobalMessage(GlobalMessageModel model)
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
                    RecipientType = (int)Enum.Parse(typeof(GlobalMessageModel.RecipientTypes), model.RecipientType)
                };

                _messageManager.AddGlobalMessage(message);
            }

            return View();
        }
    }
}