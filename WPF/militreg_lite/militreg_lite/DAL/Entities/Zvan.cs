using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.DAL.Entities
{
    public class Zvan:BaseEntity<int>
    {
        public Zvan()
        {
        }

        public Zvan(Zvan zvan)
        {
            Name = zvan.Name;
        }

        public string Name { get; set; }
    }
}
