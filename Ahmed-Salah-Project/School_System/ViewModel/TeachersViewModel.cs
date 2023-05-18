using Microsoft.Win32;
using School_System.Models;
using School_System.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using School_System.View;

namespace School_System.ViewModel
{
    public class TeachersViewModel : INotifyPropertyChanged
    {
        #region fields
        private bool flag = false;
        #endregion
        #region Implentation INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = null)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));

        }
        #endregion
        #region Constructor
        public TeachersViewModel()
        {
            TeachersList = new ObservableCollection<Teacher>()
            { new Teacher() { Id=1 , Name="ميكى" , Subject=Subject.English , Image="/Resources/images/teachers/01.jpeg"},
              new Teacher() { Id=2 , Name="بطوط" , Subject=Subject.Arabic , Image="/Resources/images/teachers/02.jpeg"},
              new Teacher() { Id=3 , Name="عم دهب" , Subject=Subject.English , Image="/Resources/images/teachers/03.jpeg"},
              new Teacher() { Id=4 , Name="بسيط" , Subject=Subject.Math , Image="/Resources/images/teachers/04.jpeg"},
              new Teacher() { Id=5 , Name="بندق" , Subject=Subject.Math , Image="/Resources/images/teachers/05.jpeg"},
            };
            SubjectList = new ObservableCollection<Subject>() { Subject.Arabic, Subject.Math, Subject.English };
            AddNew = new MyCommand(AddNewTeacher, CanAddNewTeacher);
            SaveNew = new MyCommand(SaveNewTeacher, CanSaveNewTeacher);
            Remove = new MyCommand(RemoveTeacher, CanRemoveTeacher);
            UploadPhoto = new MyCommand(UploadPhotoTeacher, CanUploadPhotoTeacher);
        }
        #endregion
        #region Property
        public ObservableCollection<Teacher> TeachersList { get; set; }
        public ObservableCollection<Subject> SubjectList { get; set; }
        public MyCommand AddNew { get; set; }
        public MyCommand SaveNew { get; set; }
        public MyCommand Remove { get; set; }
        public MyCommand UploadPhoto { get; set; }
        public Action CloseAction { get; set; }
        private Teacher _selectedItem;
        public string TeacherName { get; set; }
        public int TeacherId { get; set; }
        public string TeacherImage { get; set; }
        public Subject TeacherSubject { get; set; }

        public Teacher SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                try
                {
                    _selectedItem = value;
                    TeacherName = value.Name;
                    TeacherId = value.Id;
                    TeacherImage = value.Image;
                    TeacherSubject = value.Subject;
                    OnPropertyChanged("TeacherName");
                    OnPropertyChanged("TeacherGender");
                    OnPropertyChanged("TeacherId");
                    OnPropertyChanged("TeacherImage");
                    OnPropertyChanged("TeacherSubject");

                }
                catch (NullReferenceException)
                {
                    
                }

            }
        }
        #endregion
        #region Methods
        public void AddNewTeacher(Object parameter)
        {
            SelectedItem = null;
            TeacherName = "";
            TeacherId = 0;
            TeacherImage = "";
            TeacherSubject = Subject.Arabic;
            OnPropertyChanged("SelectedItem");
            OnPropertyChanged("TeacherName");
            OnPropertyChanged("TeacherGender");
            OnPropertyChanged("TeacherId");
            OnPropertyChanged("TeacherImage");
            OnPropertyChanged("TeacherSubject");
            flag = true;
        }
        public bool CanAddNewTeacher(Object parameter)

        {
            return true;
        }
        public void SaveNewTeacher(Object parameter)
        {
            if (flag == true)
            {
                Teacher teacher = new Teacher();
                teacher.Name = TeacherName;
                teacher.Subject = (Subject)TeacherSubject;
                teacher.Id = TeacherId;
                teacher.Image = TeacherImage;
                TeachersList.Add(teacher);
                TeacherName = "";
                TeacherId = 0;
                TeacherImage = "";
                TeacherSubject = Subject.Arabic;
                SelectedItem = teacher;
                OnPropertyChanged("SelectedItem");
                OnPropertyChanged("TeacherName");
                OnPropertyChanged("TeacherGender");
                OnPropertyChanged("TeacherId");
                OnPropertyChanged("TeacherImage");
                OnPropertyChanged("TeacherSubject");
                MessageBox.Show($" {teacher.Name} has been added successfully");

                flag = false;
            }
        }
        public bool CanSaveNewTeacher(Object parameter)

        {
            return true;
        }
        public void RemoveTeacher(Object parameter)
        {
            TeachersList.Remove((Teacher)SelectedItem);
            string temp = TeacherName;
            TeacherName = "";
            TeacherId = 0;
            TeacherImage = "";
            TeacherSubject = Subject.Arabic;
            OnPropertyChanged("TeacherName");
            OnPropertyChanged("TeacherGender");
            OnPropertyChanged("TeacherId");
            OnPropertyChanged("TeacherImage");
            OnPropertyChanged("TeacherSubject");
            SelectedItem = null;
            OnPropertyChanged("SelectedItemst");
            MessageBox.Show($" {temp} removed successfully");
        }
        public bool CanRemoveTeacher(Object parameter)

        {
            return true;
        }
        public void UploadPhotoTeacher(Object parameter)
        {
            if (flag == true)
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Select a picture";
                op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                  "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                  "Portable Network Graphic (*.png)|*.png";
                if (op.ShowDialog() == true)
                {
                    TeacherImage = (new BitmapImage(new Uri(op.FileName))).ToString();
                    OnPropertyChanged("TeacherImage");
                }
            }
        }
        public bool CanUploadPhotoTeacher(Object parameter)

        {
            return true;
        }

        #endregion
    }
}
