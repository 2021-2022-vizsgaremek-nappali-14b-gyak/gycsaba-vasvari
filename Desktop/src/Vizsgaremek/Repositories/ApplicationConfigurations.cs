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
        private string name;

        public string Name { get => name; set => name = value; }

        public ApplicationConfigurations()
        {
            var name = ConfigurationManager.AppSettings.Get("name");
        }
    }
}
