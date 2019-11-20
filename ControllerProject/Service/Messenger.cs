using Model;
using System;

namespace ControllerProject.Service
{
    public class Messenger : IMessenger
    {
        private IMessageManager _messageManager;

        public Messenger(IMessageManager messageManager)
        {
            _messageManager = messageManager;
        }

        public delegate void MessagePostedEventHandler(object source, MessagePostedEventArgs args);
        public event MessagePostedEventHandler MessagePosted;

        public void PostMessage(GlobalMessage message)
        {
            int messagesPosted = _messageManager.AddGlobalMessage(message);
            bool messagePostStatus = messagesPosted > 0 ? true : false;

            OnMessagePosted(messagePostStatus, message);
        }

        protected virtual void OnMessagePosted(bool status, GlobalMessage message)
        {
            MessagePosted?.Invoke(this, new MessagePostedEventArgs() { Status = status, Message = message });
        }
    }

    public class MessagePostedEventArgs : EventArgs
    {
        public bool Status { get; set; }
        public GlobalMessage Message { get; set; }
    }
}
