using DesafioWebMotors.Domain.ExtendsMethods;
using System.ComponentModel.DataAnnotations;

namespace DesafioWebMotors.Domain.DataAnnotationValidation
{
    public class NumberMinValueAttribute : ValidationAttribute
    {
        private readonly long _currentValue;
        public NumberMinValueAttribute(long minValue)
        {
            _currentValue = minValue;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value.ToInt64() > _currentValue)
                return ValidationResult.Success;
            else
                return new ValidationResult($"O valor mínimo é inválido. O valor esperado deve ser maior que {_currentValue}");
        }
    }
}
