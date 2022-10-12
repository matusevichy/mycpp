using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyApp.Model
{    
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Email { get; set; }
    }
}
