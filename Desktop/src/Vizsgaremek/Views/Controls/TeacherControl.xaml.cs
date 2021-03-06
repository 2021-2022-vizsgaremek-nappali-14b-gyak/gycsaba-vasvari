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

using Vizsgaremek.Models;
using Vizsgaremek.Repositories;
using Vizsgaremek.ViewModels;

namespace Vizsgaremek.Views.Controls
{
    /// <summary>
    /// Interaction logic for TecherControl.xaml
    /// </summary>
    public partial class TeacherControl : UserControl
    {
        public TeacherControl()
        {        
            InitializeComponent();
        }

        public  void ModifyTeacherInTeacherControlViewModel(TeacherControlViewModel teacherControlViewModel, Teacher selectedTeacher)
        {
            DataContext = teacherControlViewModel;
            Teacher editedTeacher = new Teacher(selectedTeacher);
            teacherControlViewModel.EditedTeacher = editedTeacher;
        }
    }
}
