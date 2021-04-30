using System.Globalization;
using System.Windows.Controls;

namespace ai_restauracje
{
    public interface IValidation
    {
        string Name { get; }

        string Description { get; }
    }

    public class NameValidation : ValidationRule, IValidation
    {
        public string Name => "Name rule";
        public string Description => "Value is not correct restaurant name";

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrEmpty((string)value) || ((string)value).Length > 60)
                return new ValidationResult(false, Description);
            else return ValidationResult.ValidResult;
        }
    }
}
