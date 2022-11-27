using System.ComponentModel.DataAnnotations;

namespace Less4_hw.Models
{
    public class Comment:BaseModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Message { get; set; }
        public Post Post { get; set; }
        public DateTime DateCreate { get; set; } = DateTime.Now;
    }
}
