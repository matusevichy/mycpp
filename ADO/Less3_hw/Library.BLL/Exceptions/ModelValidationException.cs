using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Exceptions
{
    public class ModelValidationException : SystemException
    {
        public ModelValidationException(string message) : base(message) { }
    }
}
