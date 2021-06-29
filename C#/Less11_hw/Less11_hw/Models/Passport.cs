using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Less11_hw.Models
{
    class Passport
    {
        [Required]
        [StringLength(2,MinimumLength =2, ErrorMessage = "Passport series must have 2 characters")]
        public string Series { get; set; }

        [Required]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Passport number must have 2 characters")]
        public string Number { get; set; }
        public override string ToString()
        {
            return $"{Series} No{Number}";
        }
    }
}
