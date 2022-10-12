using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.BLL.DTO
{
    public class RtckDTO:BaseDTO
    {
        public RtckDTO()
        {
        }

        public RtckDTO(RtckDTO rtck)
        {
            Name = rtck.Name;
        }
        public string Name { get; set; }
        public override bool Equals(object obj)
        {
            if ((obj as RtckDTO) != null)
            {
                return this.Id == (obj as RtckDTO).Id;
            }
            return false;
        }
    }

}
