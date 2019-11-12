using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ExpirationDate { get; set; } = DateTime.Now;

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
    }
}