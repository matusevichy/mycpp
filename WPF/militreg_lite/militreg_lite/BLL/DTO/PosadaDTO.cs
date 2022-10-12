using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.BLL.DTO
{
    public class PosadaDTO:BaseDTO
    {
        public string Name { get; set; }
        public PosadaDTO()
        {
        }

        public PosadaDTO(PosadaDTO posada)
        {
            Name = posada.Name;
        }
        public override bool Equals(object obj)
        {
            if ((obj as PosadaDTO) != null)
            {
                return this.Id == (obj as PosadaDTO).Id;
            }
            return false;
        }
    }
}
