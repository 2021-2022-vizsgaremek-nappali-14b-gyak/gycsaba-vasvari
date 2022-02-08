using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vizsgaremek.Models;

namespace Vizsgaremek.ViewModels
{
    public class TeacherControlViewModel
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
            }
        }

        public TeacherControlViewModel()
        {
            editedTeacher = new Teacher();
        }
    }
}
