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

using Vizsgaremek.Views.Navigation;
using Vizsgaremek.ViewModels;

namespace Vizsgaremek.Views.Pages
{
    /// <summary>
    /// Interaction logic for LanguageSelectionPage.xaml
    /// </summary>
    public partial class LanguageSelectionPage : UserControl
    {
        LanguageSelectionViewModel languageSelectionViewModel;

        public LanguageSelectionPage(LanguageSelectionViewModel languageSelectionViewModel)
        {
            this.languageSelectionViewModel = languageSelectionViewModel;
            InitializeComponent();
            this.DataContext = languageSelectionViewModel;
        }

        private void Image_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            WelcomePage welcomePage = new WelcomePage();
            Navigate.Navigation(welcomePage);
        }
    }
}
