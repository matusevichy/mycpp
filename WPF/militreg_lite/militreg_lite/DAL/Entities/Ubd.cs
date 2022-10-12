using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.DAL.Entities
{
    public class Ubd:BaseEntity<int>
    {
        public Ubd()
        {
        }

        public Ubd(Ubd ubd)
        {
            Name = ubd.Name;
        }

        public string Name { get; set; }
    }
}
