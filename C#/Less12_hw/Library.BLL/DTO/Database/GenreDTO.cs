using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.DTO.Database
{
    public class GenreDTO : BaseDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Длина строки должна быть 1-50 символов")]
        public string Name { get; set; }
        public List<BookDTO> Books { get; set; }
    }
}
