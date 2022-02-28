using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vizsgaremek.Models;
using Vizsgaremek.ViewModels.BaseClass;

namespace Vizsgaremek.ViewModels
{
    public class TeacherControlViewModel : ViewModelBaseClass
    {
        private Teacher editedTeacher;
        public Teacher EditedTeacher
        {
            get
            {
                return editedTeacher;
            }
            set
            {
                editedTeacher = value;
                OnPropertyChanged("EditedTeacher");
            }
        }

        public TeacherControlViewModel()
        {
            editedTeacher = new Teacher();
        }
    }
}
