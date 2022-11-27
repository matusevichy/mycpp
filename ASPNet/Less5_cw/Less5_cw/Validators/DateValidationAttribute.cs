using System.ComponentModel.DataAnnotations;

namespace Less5_cw.Validators
{
    public class DateGreaterCurrentAttribute: ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            var dateBirth = (DateTime?)value;
            if (dateBirth>DateTime.Now)
            {
                return false;
            }
            return true;
        }
    }
}
