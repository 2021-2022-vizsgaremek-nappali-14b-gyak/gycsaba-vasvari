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

        public bool NotNullOrEmpty()
        {
            if (stringToValidate == null)
            {
                return false;
            }
            if (stringToValidate == string.Empty)
            {
                errorMessage = dictionary["validationStringIsEmpty"].ToString();
                return false;
            }
            return true;
        }

        public bool FirstLetterIsUpperOtherisLower()
        {
            if (stringToValidate.Length > 0)
            {
                char firstLatter = stringToValidate.ElementAt(0);
                if (char.IsLower(firstLatter))
                {
                    errorMessage = dictionary["validationStringFirstLetterNotUpper"].ToString();
                    return false;
                }
            }
            if (stringToValidate.Length > 1)
            {
                foreach (char c in stringToValidate.Substring(1))
                {
                    if (char.IsUpper(c))
                    {
                        errorMessage = dictionary["validationStringAfterFirstLetterNotLowercase"].ToString();
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
