using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

using System.Collections.Specialized;

namespace Vizsgaremek.Repositories
{
    class ApplicationConfigurations
    {
        private string appName;
        private Dictionary<string, string> devopsVersions;
        private Dictionary<string, string> languages;

        public string AppName { get => appName; set => appName = value; }
        public Dictionary<string, string> DevopsVersions { get => devopsVersions; set => devopsVersions = value; }
        public Dictionary<string, string> Languages { get => languages; set => languages = value; }

        public ApplicationConfigurations()
        {
            var name = ConfigurationManager.AppSettings.Get("name");

            NameValueCollection devopsVersionsConfigSection = ConfigurationManager.GetSection("devopsVersions") as NameValueCollection;
            NameValueCollection lanuagesSettingsConfigSection = ConfigurationManager.GetSection("languages") as NameValueCollection;

            DevopsVersions = new Dictionary<string, string>();
            DevopsVersions = devopsVersionsConfigSection.AllKeys.ToDictionary(k => k, k => devopsVersionsConfigSection[k]);

            Languages = new Dictionary<string, string>();
            Languages = lanuagesSettingsConfigSection.AllKeys.ToDictionary(k => k, k => lanuagesSettingsConfigSection[k]);
        }
    }
}
