using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less3_hw.Models
{
    public class TopList
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public override string ToString()
        {
            return $"Word: {Name} Count:{Count}";
        }
    }
}
