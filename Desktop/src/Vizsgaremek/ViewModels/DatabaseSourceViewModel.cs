using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using Vizsgaremek.Repositories;

namespace Vizsgaremek.ViewModels
{
    class DatabaseSourceViewModel
    {
        private ObservableCollection<string> displayedDatabaseSources;
        private string selectedDatabaseSource;

        DatabaseSouerces repoDatabaseSouerces;

        public ObservableCollection<string> DisplayedDatabaseSources 
        { 
            get => displayedDatabaseSources; 
        }
        public string SelectedDatabaseSource 
        { 
            get => selectedDatabaseSource; 
            set => selectedDatabaseSource = value; 
        }

        public DatabaseSourceViewModel()
        {
            repoDatabaseSouerces = new DatabaseSouerces();
            displayedDatabaseSources = new ObservableCollection<string>(repoDatabaseSouerces.GetAllDatabaseSources());
        }
    }
}
