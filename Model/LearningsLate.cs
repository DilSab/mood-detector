using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LearningsLate
    {
        public string EmotionName { get; set; }
        public User Teacher { get; set; }
        public int Days { get; set; }
    }
}
