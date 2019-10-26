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
        public Moods CheckPhoto()
        {
            return new Moods { Joy = 99.9, Anger = 10.5 };
        }

        public class Moods
        {
            public double Joy { get; set;}
            public double Anger { get; set; }
        }
    }
}
