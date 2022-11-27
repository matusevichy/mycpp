using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.BLL.DTO
{
    public class VosDTO : BaseDTO, IDict
    {
        public string Name
        {
            get; set;
        }
        public VosDTO()
        {
        }

        public VosDTO(VosDTO vos)
        {
            Name = vos.Name;
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
