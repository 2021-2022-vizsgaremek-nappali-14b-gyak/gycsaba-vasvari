using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vizsgaremek.Models;
using Vizsgaremek.ViewModels.BaseClass;
using Vizsgaremek.Stores;
using System.Windows.Input;
using Vizsgaremek.Commands;

namespace Vizsgaremek.ViewModels
{
    public class TeacherControlViewModel : ViewModelBaseClass
    {
        private TeacherStore teacherStore;
        private Teacher editedTeacher;

        public ICommand DeleteTeacherCommand { get; }
        public ICommand ModifyTeacherCommand { get; }
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

        public TeacherControlViewModel(TeacherStore teacherStore)
        {
            editedTeacher = new Teacher();
            this.teacherStore = teacherStore;

            DeleteTeacherCommand = new DeleteTeacherCommand(this, teacherStore);
        }
    }
}
