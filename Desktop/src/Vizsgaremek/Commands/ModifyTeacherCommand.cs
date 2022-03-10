using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vizsgaremek.ViewModels;
using Vizsgaremek.Stores;

namespace Vizsgaremek.Commands
{
    class ModifyTeacherCommand : CommandBase
    {
        private readonly TeacherControlViewModel teacherControlViewModel;
        private readonly TeacherStore teacherStore;
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
