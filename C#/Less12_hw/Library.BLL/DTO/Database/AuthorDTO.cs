using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.DTO.Database
{
    public class AuthorDTO:BaseDTO
    {
        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Длина строки должна быть 1-20 символов")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Длина строки должна быть 1-30 символов")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.DateTime, ErrorMessage ="Значение должно быть в формате DateTime")]
        public DateTime Birth { get; set; }
        //public List<BookDTO> Books { get; set; }
    }
}
