using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.DAL.Entities
{
    public class Rtck:BaseEntity<int>
    {
        public Rtck()
        {
        }

        public Rtck(Rtck rtck)
        {
            Name = rtck.Name;
        }

        public string Name { get; set; }
    }
}
