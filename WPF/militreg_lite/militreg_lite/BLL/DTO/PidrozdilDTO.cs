using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.BLL.DTO
{
    public class PidrozdilDTO:BaseDTO
    {
        public string Name { get; set; }
        public PidrozdilDTO()
        {
        }

        public PidrozdilDTO(PidrozdilDTO pidrozdil)
        {
            Name = pidrozdil.Name;
        }
        public override bool Equals(object obj)
        {
            if ((obj as PidrozdilDTO) != null)
            {
                return this.Id == (obj as PidrozdilDTO).Id;
            }
            return false;
        }
    }
}
