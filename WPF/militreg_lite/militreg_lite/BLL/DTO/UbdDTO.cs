using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.BLL.DTO
{
    public class UbdDTO:BaseDTO
    {
        public string Name { get; set; }
        public UbdDTO()
        {
        }

        public UbdDTO(UbdDTO ubd)
        {
            Name = ubd.Name;
        }
        public override bool Equals(object obj)
        {
            if ((obj as UbdDTO) != null)
            {
                return this.Id == (obj as UbdDTO).Id;
            }
            return false;
        }
    }
}
