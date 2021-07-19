using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Helpers.Validation
{
    public class ModelValidationHelper
    {
        public static ValidationResult Validate<T>(T model)
        {
            var validationResult = new ValidationResult { Valid = true };
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var context = new ValidationContext(model);
            if (!Validator.TryValidateObject(model, context, results, true))
            {
                validationResult.Errors.AddRange(results.Select(res => res.ErrorMessage));
                validationResult.Valid = false;
            }
            return validationResult;
        }
    }
}
