using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.DAL.Entities
{
    public class Posada:BaseEntity<int>
    {
        public Posada()
        {
        }

        public Posada(Posada posada)
        {
            Name = posada.Name;
        }

        public string Name { get; set; }
    }
}
