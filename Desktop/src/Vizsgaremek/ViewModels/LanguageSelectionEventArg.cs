using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsgaremek.ViewModels
{
    class LanguageSelectionEventArg :EventArgs
    {
        private string selectedLanguage;
        
        public LanguageSelectionEventArg(string selectedLanguage)
        {
            this.selectedLanguage = selectedLanguage;
        }

        public string SelectedLanguage { get => selectedLanguage;  }
    }
}
