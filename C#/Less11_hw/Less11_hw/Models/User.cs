using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Less11_hw.Models
{
    class User
    {
        [Required]
        [StringLength(20,MinimumLength =2, ErrorMessage ="First name must be between 2 and 20 characters")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 30 characters")]
        public string LastName { get; set; }

        [StringLength(20, MinimumLength = 0, ErrorMessage = "Patronym must be between 2 and 20 characters")]
        public string Patronym { get; set; }

        [Required]
        [DataType(DataType.DateTime, ErrorMessage = "Incorrect date format")]
        [CustomDataRange]
        public DateTime Birth { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Countries name must be between 2 and 50 characters")]
        public string Country { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Cities name must be between 2 and 50 characters")]
        public string City { get; set; }

        [Required]
        [ValidateComplexType]
        public Passport Passport { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {Patronym} {LastName}\n" +
                $"Birth: {Birth}\n" +
                $"Country: {Country}\n" +
                $"City: {City}\n" +
                $"{Passport}";
        }
    }
}
