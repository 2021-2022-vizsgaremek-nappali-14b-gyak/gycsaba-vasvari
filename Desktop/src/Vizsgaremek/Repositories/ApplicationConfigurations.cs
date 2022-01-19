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

        public ApplicationConfigurations()
        {
            var name = ConfigurationManager.AppSettings.Get("name");

            //var devopsVersionsConfig = ConfigurationManager.AppSettings.Get("devopsVersions");            
            //var languagesConfig = ConfigurationManager.AppSettings.Get("language");

            NameValueCollection devopsVersionsConfigSection = ConfigurationManager.GetSection("devopsVersions") as NameValueCollection;
            NameValueCollection lanuagesSettingsConfigSection = ConfigurationManager.GetSection("languages") as NameValueCollection;

            devopsVersions = new Dictionary<string, string>();
            devopsVersions = devopsVersionsConfigSection.AllKeys.ToDictionary(k => k, k => devopsVersionsConfigSection[k]);
        }
    }
}
