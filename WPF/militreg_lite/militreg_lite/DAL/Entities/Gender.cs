using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.DAL.Entities
{
    public class Gender:BaseEntity<int>
    {
        public Gender()
        {
        }

        public Gender(Gender gender)
        {
            this.Name = gender.Name;
        }

        public string Name { get; set; }
    }
}
