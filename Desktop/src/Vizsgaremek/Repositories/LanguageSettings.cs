﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vizsgaremek.Models;

namespace Vizsgaremek.Repositories
{
    class LanguageSettings
    {
        private List<LanguageSetting> languageSettingsItems;
        private LanguageSetting storedSelectedLanguage;

        public LanguageSetting StoredSelectedLanguage
        { 
            get => storedSelectedLanguage; 
            set => storedSelectedLanguage = value; 
        }

        public LanguageSettings()
        {
            StoredSelectedLanguage = new LanguageSetting()
            {
                Name = Properties.Settings.Default.storedLanguage,
                ToolTip = Properties.Settings.Default.storedLanguageToolTip,
            };
        }        

        public List<LanguageSetting> GetAllLanguage()
        {
            languageSettingsItems = new List<LanguageSetting>();
            ApplicationConfigurations appConfigRepo = new ApplicationConfigurations();
            Dictionary<string, string> allPossobleLanguages = appConfigRepo.Languages;

            foreach (KeyValuePair<string, string> possibleLanguage in allPossobleLanguages)
            {
                LanguageSetting languageSetting = new LanguageSetting()
                {
                    Name = possibleLanguage.Value,
                    ToolTip = possibleLanguage.Key
                };
                languageSettingsItems.Add(languageSetting);
            }
            return languageSettingsItems;
        }
    }
}
