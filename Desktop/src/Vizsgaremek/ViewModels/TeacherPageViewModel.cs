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

        private TeacherStore teacherStore;
        private Teachers teachersRepo;
        ObservableCollection<Teacher> displayedTeachers;
        private Teacher selectedTeacher;

        private ApplicationStore applicationStore;

        private TeacherControlViewModel teacherControlViewModel;

        public TeacherControlViewModel TeacherControlViewModel
        {
            get => teacherControlViewModel;
            set => teacherControlViewModel = value;
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

        public TeacherPageViewModel(ApplicationStore applicationStore, TeacherStore teacherStore, TeacherControlViewModel teacherControlViewModel)
        {
            this.teachersRepo = new Teachers(applicationStore);
            this.displayedTeachers = new ObservableCollection<Teacher>(teachersRepo.AllTeachers);
            this.applicationStore = applicationStore;

            this.teacherControlViewModel = teacherControlViewModel;
            selectedTeacher = new Teacher();

            this.teacherStore = teacherStore;
            teacherStore.TeacherDeleteEvent += TeacherStore_TeacherDeleteEvent; 
        }

        private void TeacherStore_TeacherDeleteEvent(string id)
        {
            Teacher techerToDelete = teachersRepo.FindTeacher(id);
            if (techerToDelete != null)
            {
                DisplayedTeachers.Remove(techerToDelete);
                teachersRepo.Delete(id);
            }
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
