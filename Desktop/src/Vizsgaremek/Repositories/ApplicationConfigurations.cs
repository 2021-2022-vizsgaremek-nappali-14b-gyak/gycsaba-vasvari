using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

namespace Vizsgaremek.Repositories
{
    class ApplicationConfigurations
    {
        private string appName;

        public string AppName { get => appName; set => appName = value; }

        public ApplicationConfigurations()
        {
            appName = ConfigurationManager.AppSettings.Get("appName");
        }
    }
}
