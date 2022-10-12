using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.BLL.DTO
{
    public class GenderDTO:BaseDTO
    {
        public string Name 
        { 
            get; 
            set; 
        }
        public GenderDTO()
        {
        }

        public GenderDTO(GenderDTO gender)
        {
            this.Name = gender.Name;
        }
        public override bool Equals(object obj)
        {
            if ((obj as GenderDTO) != null)
            {
                return this.Id == (obj as GenderDTO).Id;
            }
            return false;
        }
    }
}
