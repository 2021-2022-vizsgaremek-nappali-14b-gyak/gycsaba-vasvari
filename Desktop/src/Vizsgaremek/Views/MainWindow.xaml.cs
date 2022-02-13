using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Vizsgaremek.Views.Navigations;
using Vizsgaremek.Views.Pages;
using Vizsgaremek.ViewModels;

using System.Globalization;
using System.Threading;

using Vizsgaremek.Stores;
using Vizsgaremek.Repositories;

namespace Vizsgaremek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel mainWindowViewModel;
        private DatabaseSourceViewModel databaseSourceViewModel;
        private LanguageSelectionViewModel languageSelectionViewModel;
        private TeacherPageViewModel teacherPageViewModel;

        private ApplicationStore applicationStore;

        public MainWindow()
        {
            applicationStore = new ApplicationStore();
            Navigation.mainWindow = this;

            // Különböző ablakok adatai
            mainWindowViewModel = new MainWindowViewModel();
            databaseSourceViewModel = new DatabaseSourceViewModel();
            languageSelectionViewModel = new LanguageSelectionViewModel();
            teacherPageViewModel = new TeacherPageViewModel(applicationStore);
            mainWindowViewModel.SelectedSource = databaseSourceViewModel.SelectedDatabaseSource.Name;
            applicationStore.DbSource = databaseSourceViewModel.DbSource;

            mainWindowViewModel.SelectedLanguage = languageSelectionViewModel.SelectedLanguage.Name;
            CultureInfo.CurrentCulture = new CultureInfo(languageSelectionViewModel.SelectedLanguage.ToolTip);
            ApplicationConfigurations.SelectedLanguage = languageSelectionViewModel.SelectedLanguage.ToolTip;

            // Feliratkozunk az eseményre. Ha változik az adat az adott osztályba tudni fogunk róla!
            databaseSourceViewModel.ChangeDatabaseSource += DatabaseSourceViewModel_ChangeDatabaseSource;
            languageSelectionViewModel.ChangeLanguage += LanguageSelectionViewModel_ChangeLanguage;


            InitializeComponent();
            // A MainWindow ablakban megjelenő adatok a MainWindowViewModel-ben vannak
            this.DataContext = mainWindowViewModel;
            // Statikus osztály a Navigate
            // Eltárolja a nyitó ablakt, hogy azon tudjuk módosítani a "page"-ket

            // Létrehozzuk a nyitó "UsuerControl" (WelcomPage)
            WelcomePage welcomePage = new WelcomePage();
            // Megjelnítjük a WelcomePage-t
            Navigation.Navigete(welcomePage);
        }

        private void DatabaseSourceViewModel_ChangeDatabaseSource(object sender, EventArgs e)
        {
            DatabaseSourceEventArg dsea = (DatabaseSourceEventArg) e;
            mainWindowViewModel.SelectedSource = dsea.DatabaseSource;
            ApplicationConfigurations.SelectedDatabaseSources = dsea.DatabaseSource;
            applicationStore.DbSource = databaseSourceViewModel.DbSource;
        }

        private void LanguageSelectionViewModel_ChangeLanguage(object sender, EventArgs e)
        {
            LanguageSelectionEventArg lsea = (LanguageSelectionEventArg)e;
            mainWindowViewModel.SelectedLanguage = lsea.SelectedLanguage;
            CultureInfo.CurrentCulture = new CultureInfo(languageSelectionViewModel.SelectedLanguage.ToolTip);
            ApplicationConfigurations.SelectedLanguage = languageSelectionViewModel.SelectedLanguage.ToolTip;
        }

        /// <summary>
        /// ListView elemen bal egér gomb fel lett engedve
        /// </summary>
        /// <param name="sender">ListView amin megnyomtuk a bal egér gombot</param>
        /// <param name="e"></param>
        private void ListView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ListView lvMenu = sender as ListView;
            ListViewItem lvMenuItem = lvMenu.SelectedItem as ListViewItem;
            //ListViewItem lvMenuItem = (ListViewItem) lvMenu.SelectedItem;

            if (lvMenuItem != null)
            {
                // x:Name tulajdonságot vizsgáljuk
                switch (lvMenuItem.Name)
                {
                    case "lviExit":
                        Close();
                        break;
                    case "lviTeacher":
                        TeacherPage teacherPage = new TeacherPage(teacherPageViewModel);
                        Navigation.Navigete(teacherPage);
                        break;
                    case "lviLanguageSelection":
                        LanguageSelectionPage languageSelectionPage = new LanguageSelectionPage(languageSelectionViewModel);
                        Navigation.Navigete(languageSelectionPage);
                        break;
                    case "lviDatabaseSouceSelection":
                        DatabaseSourcePage databaseSourcePage = new DatabaseSourcePage(databaseSourceViewModel);
                        Navigation.Navigete(databaseSourcePage);
                        break;
                    case "lviProgramVersion":
                        ProgramInfo programVersion = new ProgramInfo();
                        Navigation.Navigete(programVersion);
                        break;
                }                
            }
        }
    }
}

