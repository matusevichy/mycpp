using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.DAL.Entities
{
    public class Vos:BaseEntity<int>
    {
        public Vos()
        {
        }

        public Vos(Vos vos)
        {
            Number = vos.Number;
        }

        public string Number { get; set; }
    }
}
