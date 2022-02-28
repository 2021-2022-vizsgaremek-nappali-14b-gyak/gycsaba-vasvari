﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vizsgaremek.ViewModels;
using Vizsgaremek.Stores;

namespace Vizsgaremek.Commands
{
    class DeleteTeacherCommand : CommandBase
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

        public override bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
