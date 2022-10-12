using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.DAL.Entities
{
    public class Pidrozdil:BaseEntity<int>
    {
        public Pidrozdil()
        {
        }

        public Pidrozdil(Pidrozdil pidrozdil)
        {
            Name = pidrozdil.Name;
        }

        public string Name { get; set; }
    }
}
