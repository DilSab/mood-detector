using ControllerProject.Service;
using System;
using System.IO;

namespace ControllerProject.Logger
{
    public class MessageLogger : BaseLogger, IMessageLogger
    {
        private string filePath = "MoodDetector\\Logs\\MoodDetectorLogs.txt";

        public override void Log(string message)
        {
            string directory = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(message);
            }
        }

        public void OnMessagePosted(object source, MessagePostedEventArgs args)
        {
            string statusMessage = args.Status ? " Message posted successfully. " : " Error posting message. ";
            string message = DateTime.Now.ToString() + statusMessage + " Message ID: " + args.Message.Id.ToString() + " User ID: " + args.Message.User.Id;

            Log(message);
        }
    }
}
