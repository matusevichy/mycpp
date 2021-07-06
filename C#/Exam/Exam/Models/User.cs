using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Exam.Models
{
    [Serializable]
    class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength =4, ErrorMessage ="Длинна логина должна быть от 4 до 20 символов")]
        public string Login { get; set; }

        [Required]
        [StringLength(20, MinimumLength =8, ErrorMessage ="Длинна пароля должна быть от 8 до 20 символов")]
        [RegularExpression(@"^[a-zA-Z0-9]+$",ErrorMessage ="Пароль может содержать только латинские буквы в верхнем и нижнем регистре и цифры от 0 до 9")]
        public string  Password { get; set; }

        [Required]
        [DataType(DataType.DateTime, ErrorMessage ="Проверьте формат введенной даты")]
        public DateTime Birth { get; set; }
        public bool IsAdmin { get; set; }
        public override string ToString()
        {
            return $"Id: {Id}\tLogin: {Login}\tBirth:{Birth}\tIsAdmin: {IsAdmin}";
        }
    }
}
