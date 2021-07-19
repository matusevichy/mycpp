using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Helpers.Validation
{
    public class ValidationResult
    {
        public bool Valid { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}
