using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.BLL.DTO
{
    public class VosDTO : BaseDTO
    {
        public string Number
        {
            get; set;
        }
        public VosDTO()
        {
        }

        public VosDTO(VosDTO vos)
        {
            Number = vos.Number;
        }
        public override bool Equals(object obj)
        {
            if ((obj as VosDTO) != null)
            {
                return this.Id == (obj as VosDTO).Id;
            }
            return false;
        }
    }
}
