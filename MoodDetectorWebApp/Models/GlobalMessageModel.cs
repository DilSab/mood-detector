using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MoodDetectorWebApp.Models
{
    public class GlobalMessageModel
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Title { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 1)]
        public string Content { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ExpirationDate { get; set; } = DateTime.Now;

        [Required]
        public string RecipientType { get; set; }

        public enum RecipientTypes
        {
            All = 0,
            Admin = 1,
            Teacher = 2,
        }

        public static string[] GetAllRecipientTypes()
        {
            return Enum.GetNames(typeof(RecipientTypes));
        }

        public static string GetExpirationMessage(DateTime? expirationDate)
        {
            if (!expirationDate.HasValue)
            {
                return "Message has no expiration date";
            }

            return expirationDate.Value.Ticks < DateTime.Now.Ticks
                ? string.Format("Expired: {0}", expirationDate.ToString())
                : string.Format("Expires in: {0}", GetFormattedTimeTillExpiration(expirationDate));
        }

        public static string GetFormattedTimeTillExpiration(DateTime? expirationDate)
        {
            TimeSpan span = expirationDate.Value.Subtract(DateTime.Now);
            var timeFormatted = new StringBuilder("");
            if (span.Days != 0) timeFormatted.AppendFormat("{0} days, ", span.Days);
            if (span.Hours != 0) timeFormatted.AppendFormat("{0} hours, ", span.Hours);
            if (span.Minutes != 0) timeFormatted.AppendFormat("{0} minutes, ", span.Minutes);
            if (span.Seconds != 0) timeFormatted.AppendFormat("{0} seconds, ", span.Seconds);

            return timeFormatted.ToString();
        }
    }
}