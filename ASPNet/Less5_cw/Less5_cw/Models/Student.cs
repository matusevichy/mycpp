using Less5_cw.Validators;
using System.ComponentModel.DataAnnotations;

namespace Less5_cw.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Display(Name ="Имя")]
        [Required(ErrorMessage ="Поле Имя не может быть пустым!")]
        [RegularExpression(@"^[A-Za-zА-Яа-я]+",ErrorMessage = "Поле может содержать только буквы!")]
        [StringLength(15)]
        public string FirstName { get; set; }
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Поле Фамилия не может быть пустым!")]
        [RegularExpression(@"^[A-Za-zА-Яа-я]+", ErrorMessage = "Поле может содержать только буквы!")]
        [StringLength(15)]
        public string LastName { get; set; }
        [Display(Name ="Дата рождения")]
        [DataType(DataType.Date)]
        [DateGreaterCurrent(ErrorMessage = "Дата рождения не может быть больше текущей!")]
        public DateTime BirhtDay { get; set; }
    }
}
