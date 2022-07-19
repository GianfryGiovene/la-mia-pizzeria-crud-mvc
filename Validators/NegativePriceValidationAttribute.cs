using System.ComponentModel.DataAnnotations;

namespace LaMiaPizzeria.Validators
{
    public class NegativePriceValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            double fieldValue = (double)value;
            if (fieldValue <= 0)
            {
                return new ValidationResult("Il prezzo che hai inserito è minore di 0!! Sicuro di volerci perdere?");
            }

            return ValidationResult.Success;
        }
    }
}
