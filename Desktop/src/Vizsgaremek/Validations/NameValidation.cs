using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;
using Vizsgaremek.Validations.ValidationRules;

namespace Vizsgaremek.Validations
{
    class NameValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string)
            {
                string stringToValidate = (string)value;
                OnNameValidation sv = new OnNameValidation(stringToValidate);
                if (!sv.NotNullOrEmpty())
                    return new ValidationResult(false, sv.ErrorMessage);
                if (!sv.FirstLetterIsUpperOtherisLower())
                    return new ValidationResult(false, sv.ErrorMessage);
                if (!sv.StringIsEnoughLength(5))
                    return new ValidationResult(false, sv.ErrorMessage);
            }
            else
                return new ValidationResult(true, "");
        }
    }
}
