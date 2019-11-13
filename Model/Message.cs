using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Message
    {
        public string Text { get; set; }
        public int SessionId { get; set; }
        public int Mask { get; set; }
        public string Link { get; set; }
        public long SessionTime { get; set; }
    }
}
