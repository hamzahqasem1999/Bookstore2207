using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore2207.helpers
{
    public class HierdateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (Convert.ToDateTime(value) > DateTime.Now)
                {

                    return new ValidationResult("hierdate shouhdnt grater than cuurnt date");
                }
                else

                {
                    return ValidationResult.Success;

                }


            }
            else
            {
                return new ValidationResult("hierdate is required");
            }
        }
    }
}
