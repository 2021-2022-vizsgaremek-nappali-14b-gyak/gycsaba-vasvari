using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

using System.Collections.Specialized;

namespace Vizsgaremek.Repositories
{
    public static class ApplicationConfigurations
    {
        private static string selectedLanguage;
        private static string selectedDatabaseSources;

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
    }
}
