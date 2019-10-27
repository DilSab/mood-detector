using Microsoft.AspNetCore.Mvc;
using Controller.Service;
using Controller;
using System;
using System.Collections.Generic;

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

        public class Moods
        {
            public int Id { get; set; }
            public double Joy { get; set; }
            public double Anger { get; set; }
        }
    }
}
