using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.DTO.Database
{
    public class BookDTO:BaseDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Длина строки должна быть 1-50 символов")]
        public string Title { get; set; }
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Колличество страниц должно быть целым числом >0")]
        public int Pages { get; set; }
        public string Description { get; set; }
        public int InStock { get; set; }
        public GenreDTO Genre { get; set; }
        public List<AuthorDTO> Authors { get; set; }
        public List<UserDTO> OnHands { get; set; } = null;

    }
}
