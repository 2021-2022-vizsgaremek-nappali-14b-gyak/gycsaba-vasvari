using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vizsgaremek.Repositories;
using System.Collections.ObjectModel;
using Vizsgaremek.Models;
using Vizsgaremek.Stores;
using Vizsgaremek.ViewModels.BaseClass;

namespace Vizsgaremek.ViewModels
{
    public class TeacherPageViewModel : ViewModelBaseClass
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
                    OnPropertyChanged("SelectedTeacher");
                    OnPropertyChanged("SelectedTeacherIndex");
                }
            }
        }

        public int SelectedTeacherIndex
        {
            get
            {
                if (displayedTeachers != null && teachersRepo!=null && displayedTeachers.Count > 0)
                {
                    Teacher teacher = teachersRepo.FindTeacher(SelectedTeacher.Id);
                    int index = displayedTeachers.IndexOf(teacher);
                    return index;

                }
                else
                    return -1;
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
            teacherStore.TeacherModifyEvent += TeacherStore_TeacherModifyEvent;
        }
        private void TeacherStore_TeacherModifyEvent(Teacher modifydTeacher)
        {
            string teacherId = modifydTeacher.Id;
            if (teachersRepo.IsTeacherExsist(teacherId))
            {
                teachersRepo.Update(teacherId, modifydTeacher);
                DisplayedTeachers.Clear();
                DisplayedTeachers = new ObservableCollection<Teacher>(teachersRepo.AllTeachers);
                SelectedTeacher = modifydTeacher;
            }
        }

        private void TeacherStore_TeacherDeleteEvent(string id)
        {
            Teacher techerToDelete = teachersRepo.FindTeacher(id);
            if (techerToDelete != null)
            {
                DisplayedTeachers.Remove(techerToDelete);
                teachersRepo.Delete(id);
                OnPropertyChanged("DisplayedTeachers");
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
            set
            {
                displayedTeachers = value;
                OnPropertyChanged("DisplayedTeachers");
            }
        }

    }
}
