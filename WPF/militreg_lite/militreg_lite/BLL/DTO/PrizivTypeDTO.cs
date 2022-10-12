using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.BLL.DTO
{
    public class PrizivTypeDTO:BaseDTO
    {
        public string Name { get; set; }
        public PrizivTypeDTO()
        {
        }

        public PrizivTypeDTO(PrizivTypeDTO prizivType)
        {
            Name = prizivType.Name;
        }
        public override bool Equals(object obj)
        {
            if ((obj as PrizivTypeDTO) != null)
            {
                return this.Id == (obj as PrizivTypeDTO).Id;
            }
            return false;
        }
    }
}
