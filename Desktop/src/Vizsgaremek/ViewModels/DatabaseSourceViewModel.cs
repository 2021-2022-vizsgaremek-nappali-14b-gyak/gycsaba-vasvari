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
        private ObservableCollection<string> displayedDatabaseSource;
        private string selectedDatabaseSource;
        DatabaseSouerces repoDatabaseSouerces;


        public ObservableCollection<string> DisplayedDatabaseSource 
        { 
            get => displayedDatabaseSource; 
        }
        public string SelectedDatabaseSource 
        { 
            get => selectedDatabaseSource; 
            set => selectedDatabaseSource = value; 
        }

        public DatabaseSourceViewModel()
        {
            repoDatabaseSouerces = new DatabaseSouerces();
            displayedDatabaseSource = new ObservableCollection<string>(repoDatabaseSouerces.GetAllDatabaseSources());

        }
    }
}
