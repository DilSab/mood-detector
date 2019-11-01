using Microsoft.AspNetCore.Mvc;
using ControllerProject.Service;
using ControllerProject;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Web.Http;
using System.IO;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    public class AffectivaTestController
    {
        [HttpGet("[action]")]
        public List<Moods> CheckPhoto()
        {
            return new List<Moods>
            {
                new Moods { Id = 1, Joy = 99.9, Anger = 10.5 },
                new Moods { Id = 2, Joy = 21.9, Anger = 78.7 },
                new Moods { Id = 3, Joy = 31.4, Anger = 22.3 },
            };
        }

        [HttpPost("api/person")]
        public ActionResult Student([FromForm]Person std)
        {
            // Getting Name
            string name = std.Name;
            // Getting Image
            var image = std.Image;
            // Saving Image on Server
            if (image.Length > 0)
            {
                using (var fileStream = new FileStream(image.FileName, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
            }
            return new ObjectResult(new { status = true, message = "Student Posted Successfully" });
        }

        public class Person
        {
            public string Name { get; set; }
            public IFormFile Image { get; set; }
        }

        public class Moods
        {
            public int Id { get; set; }
            public double Joy { get; set; }
            public double Anger { get; set; }
            public IFormFile Image { get; set; }
        }
    }
}
