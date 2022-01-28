using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using Vizsgaremek.Models;
using Vizsgaremek.Repositories;

namespace Vizsgaremek.ViewModels
{
    public class LanguageSelectionViewModel
    {
        private ObservableCollection<LanguageSetting> displayedLagugages;
        private LanguageSetting selectedLanguage;
        private LanguageSettings repoLanguage;

        public ObservableCollection<LanguageSetting> DisplayedLagugages { get => displayedLagugages; }

        public LanguageSetting SelectedLanguage
        {
            get => selectedLanguage;
            set
            {
                selectedLanguage = value;
                Properties.Settings.Default.storedLanguage = selectedLanguage.Name;
                Properties.Settings.Default.storedLanguageToolTip = selectedLanguage.ToolTip;
                Properties.Settings.Default.Save();

                OnLanguageChange();
            }

        }

        public event EventHandler ChangeLanguage;

        public LanguageSelectionViewModel()
        {
            repoLanguage = new LanguageSettings();
            displayedLagugages = new ObservableCollection<LanguageSetting>(repoLanguage.GetAllLanguage());
            SelectedLanguage = repoLanguage.StoredSelectedLanguage;
        }

        protected void OnLanguageChange()
        {
            LanguageSelectionEventArg lsea = new LanguageSelectionEventArg(selectedLanguage.Name);
            if (ChangeLanguage != null)
                ChangeLanguage.Invoke(this, lsea);
        }

    }
}
