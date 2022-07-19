using System.ComponentModel.DataAnnotations;

namespace LaMiaPizzeria.Validators
{
    public class MoreThanFiveWordValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string fieldValue = (string)value;
            if (fieldValue.Trim().IndexOf(" ") == -1 || fieldValue.Split(" ").Count() < 5)
            {
                return new ValidationResult("Devi inserire almeno 5 parole");
            }

            return ValidationResult.Success;
        }
    }
}
