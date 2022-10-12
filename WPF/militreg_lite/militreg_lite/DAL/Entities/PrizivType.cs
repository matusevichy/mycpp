using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.DAL.Entities
{
    public class PrizivType:BaseEntity<int>
    {
        public PrizivType()
        {
        }

        public PrizivType(PrizivType prizivType)
        {
            Name = prizivType.Name;
        }

        public string Name { get; set; }
    }
}
