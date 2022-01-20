using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsgaremek.Models
{
    public class LanguageSetting
    {
        string name;
        string toolTip;

        public string Name { get => name; set => name = value; }
        public string ToolTip { get => toolTip; set => toolTip = value; }

        public LanguageSetting()
        {
        }

        public LanguageSetting(string name, string toolTip)
        {
            this.name = name;
            this.toolTip = toolTip;
        }
    }
}
