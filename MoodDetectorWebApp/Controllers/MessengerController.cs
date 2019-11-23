using ControllerProject.Logger;
using ControllerProject.Service;
using Model;
using MoodDetectorWebApp.Models;
using System;
using System.Web.Mvc;

namespace MoodDetectorWebApp.Controllers
{
    public class MessengerController : Controller
    {
        private IMessenger _messenger;
        private IMessageLogger _messageLogger;
        private IMessageManager _messageManager;
        private IUserService _userService;

        public MessengerController(
            IMessageLogger messageLogger,
            IMessenger messenger,
            IMessageManager messageManager,
            IUserService userService
            )
        {
            _messageLogger = messageLogger;
            _messenger = messenger;
            _messageManager = messageManager;
            _userService = userService;
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
            User user = _userService.GetUser(System.Web.HttpContext.Current.User.Identity.Name);
            var globalMessages = user == null ? _messageManager.GetRecipientsAllGlobalMessages() : _messageManager.GetRecipientGlobalMessages(user);

            return PartialView("~/Views/Messenger/Sidebar.cshtml", globalMessages);
        }

        public object LoadRecipientGlobalMessages()
        {
            User user = _userService.GetUser(System.Web.HttpContext.Current.User.Identity.Name);

            int messageCount = user == null ? _messageManager.GetGlobalMessageRecipientsAllCount() : _messageManager.GetGlobalMessageCountByUser(user);

            return Json(new { success = true, count = messageCount }, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGlobalMessage(int id)
        {
            _messageManager.DeleteGlobalMessageById(id);

            return RedirectToAction("GlobalMessage");
        }


        // POST: Detector
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostGlobalMessage(GlobalMessageModel model)
        {
            if (ModelState.IsValid)
            {
                User user = _userService.GetUser(System.Web.HttpContext.Current.User.Identity.Name);
                GlobalMessage message = new GlobalMessage()
                {
                    Title = model.Title,
                    PostedDate = DateTime.Now,
                    UserId = user.Id,
                    Content = model.Content,
                    ExpirationDate = model.ExpirationDate,
                    RecipientType = model.RecipientType
                };

                _messenger.MessagePosted += _messageLogger.OnMessagePosted;

                _messenger.PostMessage(message);

                return RedirectToAction("GlobalMessage");
            }

            return View("~/Views/Messenger/GlobalMessage.cshtml", model);
        }
    }
}