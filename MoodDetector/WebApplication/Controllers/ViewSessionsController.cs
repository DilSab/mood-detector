using Controller.Service;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    public class ViewSessionsController
    {
        [HttpGet("[action]")]
        public List<Mood> GetMoods()
        {
            MoodService moodService = new MoodService(new MoodDetectorDBEntities());
            var user = new User()
            {
                Id = 3
            };

            return moodService.GetMoodsByDate(user);
        }
    }
}
