using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using Vizsgaremek.Repositories;
using Vizsgaremek.Models;

namespace Vizsgaremek.ViewModels
{
    public class DatabaseSourceViewModel
    {
        private ObservableCollection<string> displayedDatabaseSources;
        private string selectedDatabaseSource;
        private DbSource dbSource;

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

        public DbSource DbSource
        {
            get
            {
                // TDD fejlesztés
                return DbSource.NONE;
            }
        }

        public DatabaseSourceViewModel()
        {
            repoDatabaseSouerces = new DatabaseSouerces();
            displayedDatabaseSources = new ObservableCollection<string>(repoDatabaseSouerces.GetAllDatabaseSources());
        }
    }
}
