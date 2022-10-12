using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.BLL.DTO
{
    public class ZvanDTO:BaseDTO
    {
        public string Name { get; set; }
        public ZvanDTO()
        {
        }

        public ZvanDTO(ZvanDTO zvan)
        {
            Name = zvan.Name;
        }
        public override bool Equals(object obj)
        {
            if ((obj as ZvanDTO) != null)
            {
                return this.Id == (obj as ZvanDTO).Id;
            }
            return false;
        }

    }
}
