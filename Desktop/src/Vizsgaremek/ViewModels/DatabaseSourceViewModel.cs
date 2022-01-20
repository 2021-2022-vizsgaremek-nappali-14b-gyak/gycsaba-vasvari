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
        private ObservableCollection<DatabaseSource> displayedDatabaseSources;
        private DatabaseSource selectedDatabaseSource;
        private DatabaseSource displayedDatabaseSource;
        private DbSource dbSource;

        private DatabaseSources repoDatabaseSouerces;

        public ObservableCollection<DatabaseSource> DisplayedDatabaseSources 
        { 
            get => displayedDatabaseSources; 
        }
        public DatabaseSource SelectedDatabaseSource 
        { 
            get => selectedDatabaseSource;
            set
            {
                selectedDatabaseSource = value;
                displayedDatabaseSource = value;

                Properties.Settings.Default.storedDataSource = selectedDatabaseSource.Name;
                Properties.Settings.Default.storedDataSourceToolTip = selectedDatabaseSource.ToolTip;
                Properties.Settings.Default.Save();

                string proba = Properties.Settings.Default.storedDataSource;

                displayedDatabaseSource = DisplayedDatabaseSource;
                dbSource = DbSource;
                OnDatabaseSourceChange();
            }
        }

        public DbSource DbSource
        {
            get
            {
                return selectedDatabaseSource.DbSource;
            }
        }

        public DatabaseSource DisplayedDatabaseSource 
        {
            get
            {
                return displayedDatabaseSource;
            }
            
        }

        // Erre az eseményre iratkozhat fel egy másik osztály
        public event EventHandler ChangeDatabaseSource;

        public DatabaseSourceViewModel()
        {
            repoDatabaseSouerces = new DatabaseSources();
            displayedDatabaseSources = new ObservableCollection<DatabaseSource>(repoDatabaseSouerces.GetAllDatabaseSources());
            SelectedDatabaseSource = repoDatabaseSouerces.StoredSelectedSource;
        }

        // Esemény kiváltása (raise)
        protected void OnDatabaseSourceChange()
        {
            // Argumentumba belepakoljuk az üzenetet
            DatabaseSourceEventArg dsea = new DatabaseSourceEventArg(DisplayedDatabaseSource.Name);
            // Ha van esemény akkor meghívjük a feliratkozott osztályokat;
            if (ChangeDatabaseSource != null)
                ChangeDatabaseSource.Invoke(this, dsea);
        }

    }
}
