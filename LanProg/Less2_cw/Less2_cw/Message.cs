using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less2_cw
{
    internal class Message
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

    }
}
