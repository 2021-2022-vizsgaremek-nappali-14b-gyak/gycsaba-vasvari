using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vizsgaremek.ViewModels;
using Vizsgaremek.Stores;

namespace Vizsgaremek.Command
{
    class DeleteTeacherCommand
    {
        // Ez a ViewModel tudja melyik tanárt kell törölni
        private readonly TeacherControlViewModel teacherControlViewModel;
        // Ebben a Store-ban valósítjuk meg a törlést
        private readonly TeacherStore teacherStore;

        public DeleteTeacherCommand(TeacherControlViewModel teacherControlViewModel, TeacherStore teacherStore)
        {
            this.teacherControlViewModel = teacherControlViewModel;
            this.teacherStore = teacherStore;
        }
    }
}
