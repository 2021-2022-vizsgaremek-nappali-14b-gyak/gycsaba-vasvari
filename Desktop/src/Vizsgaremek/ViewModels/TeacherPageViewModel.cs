using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vizsgaremek.Repositories;
using System.Collections.ObjectModel;
using Vizsgaremek.Models;
using Vizsgaremek.Stores;

namespace Vizsgaremek.ViewModels
{
    public class TeacherPageViewModel
    { 

        private Teachers teachersRepo;
        ObservableCollection<Teacher> displayedTeachers;
        private Teacher selectedTeacher;

        private ApplicationStore applicationStore;

        private TeacherControlViewModel teacherControlViewModels;

        public TeacherControlViewModel TeacherControlViewModels
        {
            get => teacherControlViewModels;
            set => teacherControlViewModels = value;
        }

        public Teacher SelectedTeacher
        {
            get
            {
                return selectedTeacher;
            }

            set
            {
                Teacher selectedTeacherInDataGrid = value as Teacher;
                if (selectedTeacherInDataGrid != null)
                {
                    selectedTeacher = value;

                }
            }
        }

        public TeacherPageViewModel(ApplicationStore applicationStore, TeacherStore teacherStore, TeacherControlViewModel teacherControlViewModels)
        {
            this.teachersRepo = new Teachers(applicationStore);
            this.displayedTeachers = new ObservableCollection<Teacher>(teachersRepo.AllTeachers);
            this.applicationStore = applicationStore;

            teacherControlViewModels =
            selectedTeacher = new Teacher();
        }

        public ObservableCollection<Teacher> DisplayedTeachers
        {
            get
            {
                displayedTeachers.Clear();
                displayedTeachers = new ObservableCollection<Teacher>(teachersRepo.AllTeachers);
                return displayedTeachers;
            }
        }

    }
}
