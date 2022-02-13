using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

using System.Collections.Specialized;
using System.Windows;
using System.Threading;

using Vizsgaremek.Views.Navigations;

namespace Vizsgaremek.Repositories
{
    public static class ApplicationConfigurations
    {
        private static string selectedLanguage;
        private static string selectedDatabaseSources;
        private static ResourceDictionary resourceDictionary;

        private static string appName;
        private static Dictionary<string, string> databaseSources;
        private static Dictionary<string, string> languages;

        public static string AppName { get => appName; set => appName = value; }
        public static Dictionary<string, string> DatabaseSources { get => databaseSources; set => databaseSources = value; }
        public static Dictionary<string, string> Languages { get => languages; set => languages = value; }
        public static string SelectedLanguage { get => selectedLanguage; set => selectedLanguage = value; }
        public static string SelectedDatabaseSources { get => selectedDatabaseSources; set => selectedDatabaseSources = value; }

        static ApplicationConfigurations()
        {
            var name = ConfigurationManager.AppSettings.Get("name");

            selectedLanguage = Properties.Settings.Default.storedLanguageToolTip;
            selectedDatabaseSources = Properties.Settings.Default.storedDataSource;

            NameValueCollection devopsVersionsConfigSection = ConfigurationManager.GetSection("devopsVersions") as NameValueCollection;
            NameValueCollection lanuagesSettingsConfigSection = ConfigurationManager.GetSection("languages") as NameValueCollection;

            databaseSources = new Dictionary<string, string>();
            databaseSources = devopsVersionsConfigSection.AllKeys.ToDictionary(k => k, k => devopsVersionsConfigSection[k]);

            languages = new Dictionary<string, string>();
            languages = lanuagesSettingsConfigSection.AllKeys.ToDictionary(k => k, k => lanuagesSettingsConfigSection[k]);
        }

        private static void SetLanguageDictionary()
        {
            resourceDictionary = new ResourceDictionary();
            switch (Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName)
            {
                case "en":
                    resourceDictionary.Source = new Uri("..\\Resources\\en\\StringResources.xaml", UriKind.Relative);
                    break;

                case "fr":
                    resourceDictionary.Source = new Uri("..\\Resources\\fr\\StringResources.xaml", UriKind.Relative);
                    break;
                case "hu":
                    resourceDictionary.Source = new Uri("..\\Resources\\hu\\StringResources.xaml", UriKind.Relative);
                    break;
                default:
                    resourceDictionary.Source = new Uri("..\\Resources\\StringResources.xaml", UriKind.Relative);
                    break;
            }
            int langDictId = -1;
            bool found = false;
            for (int i = 0; i < Navigation.mainWindow.Resources.MergedDictionaries.Count && !found; i++)
            {
                var md = Navigation.mainWindow.Resources.MergedDictionaries[i].Source.ToString(); ;
                if (md.Contains(Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName))
                {
                    langDictId = i;
                    found = true;
                }
            }
            if (!found)
            {
                Navigation.mainWindow.Resources.MergedDictionaries.Add(resourceDictionary);
            }
            else
            {
                Navigation.mainWindow.Resources.MergedDictionaries[langDictId] = resourceDictionary;
            }
        }

        public static int GetLanguageDictionaryIndex()
        {
            int langDictId = -1;
            bool found = false;
            for (int i = 0; i < Navigation.mainWindow.Resources.MergedDictionaries.Count && !found; i++)
            {
                var md = Navigation.mainWindow.Resources.MergedDictionaries[i].Source.ToString(); ;
                if (md.Contains(Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName))
                {
                    langDictId = i;
                    found = true;
                }
            }
            if (!found)
            {
                return -1;
            }
            else
            {
                return langDictId;
            }
        }
    }
}
