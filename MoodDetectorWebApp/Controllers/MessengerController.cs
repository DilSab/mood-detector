using ControllerProject.Service;
using Model;
using MoodDetectorWebApp.Models;
using System;
using System.Text;
using System.Web.Mvc;
using System.Web.Services;

namespace MoodDetectorWebApp.Controllers
{
    public class MessengerController : Controller
    {
        private IMessageManager _messageManager;
        private IUserService _userService;

        public MessengerController(IMessageManager messageManager, IUserService userService)
        {
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
            var globalMessages = _messageManager.GetGlobalMessagesByUser(user);

            return PartialView("~/Views/Messenger/Sidebar.cshtml", globalMessages);
        }

        public object LoadRecipientGlobalMessages()
        {
            User user = _userService.GetUser(System.Web.HttpContext.Current.User.Identity.Name);
            var globalMessages = _messageManager.GetRecipientGlobalMessages(user);

            return Json(new { success = true, count = globalMessages.Count }, JsonRequestBehavior.AllowGet); ;
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

                _messageManager.AddGlobalMessage(message);
            }

            return RedirectToAction("GlobalMessage");
        }
    }
}