using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using Vizsgaremek.Repositories;

namespace Vizsgaremek.Validations.ValidationRules
{
    class OnNameValidation
    {
        private string stringToValidate;
        private string errorMessage;
        private ResourceDictionary dictionary;

        public string ErrorMessage { get => errorMessage; }

        public OnNameValidation(string nameToValidate)
        {
            this.stringToValidate = nameToValidate;
            errorMessage = string.Empty;

            dictionary = ApplicationConfigurations.GetActualDictionary();
        }
    }
}
