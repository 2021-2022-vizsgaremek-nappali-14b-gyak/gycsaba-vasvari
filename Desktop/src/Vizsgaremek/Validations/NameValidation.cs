using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;

namespace Vizsgaremek.Validations
{
    class NameValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string)
            {
                string stringToValidate = (string)value;
            }
            else
                return new ValidationResult(true, "");
        }
    }
}
