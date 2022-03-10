using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vizsgaremek.ViewModels;
using Vizsgaremek.Stores;

using Vizsgaremek.Models;

namespace Vizsgaremek.Commands
{
    class ModifyTeacherCommand : CommandBase
    {
        private readonly TeacherControlViewModel teacherControlViewModel;
        private readonly TeacherStore teacherStore;

        public ModifyTeacherCommand(TeacherControlViewModel teacherControlViewModel, TeacherStore teacherStore)
        {
            this.teacherControlViewModel = teacherControlViewModel;
            this.teacherStore = teacherStore;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            Teacher modifyTeacher = new Teacher()
            {
                Id = teacherControlViewModel.EditedTeacher.Id,
                FirstName = teacherControlViewModel.EditedTeacher.FirstName,
                LastName = teacherControlViewModel.EditedTeacher.LastName,
                Meal = teacherControlViewModel.EditedTeacher.Meal,
                Emploeyment = teacherControlViewModel.EditedTeacher.Emploeyment,
                Password = teacherControlViewModel.EditedTeacher.Password
            };
        }
    }
}
