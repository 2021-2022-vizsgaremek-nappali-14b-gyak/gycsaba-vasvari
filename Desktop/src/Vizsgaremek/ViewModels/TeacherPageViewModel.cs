using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vizsgaremek.Repositories;
using System.Collections.ObjectModel;
using Vizsgaremek.Models;

namespace Vizsgaremek.ViewModels
{
    class TeacherPageViewModel
    { 

        private Teachers teachersRepo;
        ObservableCollection<Teacher> displayedTeachers;

        public TeacherPageViewModel()
        {
            teachersRepo = new Teachers();
            displayedTeachers = new ObservableCollection<Teacher>(teachersRepo.AllTeachers);
        }

        public ObservableCollection<Teacher> DisplayedTeachers
        {
            get
            {
                return displayedTeachers;
            }
        }

    }
}
