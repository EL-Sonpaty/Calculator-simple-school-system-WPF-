using School_System.Models;
using School_System.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace School_System.ViewModel
{
    public class SubjectsViewModel : INotifyPropertyChanged
    {
        #region Fields
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
        public SubjectsViewModel()
        {
            studentsarabic = new List<Students>() { 
              new Students() { Id=2 , Name="hamada" ,Subjects_="Arabic , English "  },
              new Students() { Id=3 , Name="hossam", Subjects_="Arabic , English , Math"  }, 
                new Students() { Id=4 , Name="zakaria", Subjects_="Arabic"   }, 
                new Students() { Id=5 , Name="zienb", Subjects_="Arabic , Math"  }
            };

            studentsenglish = new List<Students>() { new Students() { 
                Id=1 , Name="marwan",Subjects_ = "math , english" },
              new Students() { Id=2 , Name="hamada" ,Subjects_="Arabic , English "  },
              new Students() { Id=3 , Name="hossam", Subjects_="Arabic , English , Math"  } };

            studentsmath = new List<Students>(){ new Students() { 
                Id=1 , Name="marwan",Subjects_ = "math , english" },
             
              new Students() { Id=3 , Name="hossam", Subjects_="Arabic , English , Math"  }, 
                new Students() { Id=5 , Name="zienb", Subjects_="Arabic , Math"  }
            };


            SubjectsList = new ObservableCollection<Subjects>()
            { new Subjects("Arabic"),
              new Subjects("English"),
              new Subjects("Math"),
            };
            BackToMain = new MyCommand(BackTofirst, CanBackTofirst);

        }
        #endregion
        #region Parametars
        public ObservableCollection<Subjects> SubjectsList { get; set; }
        public MyCommand BackToMain { get; set; }

        public List<Students> studentsarabic { get; set; }
        public List<Students> studentsenglish { get; set; }
        public List<Students> studentsmath { get; set; }
        public Action CloseActionsu { get; set; }

        public List<Students> DatagridData { get; set; }
        private Subjects _selectedSubject;
        public Subjects SelectedSubject
        {
            get { return _selectedSubject; }
            set
            {
                try
                {
                    _selectedSubject = value;
                    if (value.Name == "Arabic")
                    {
                        DatagridData = studentsarabic;
                    }
                  
                    else if (value.Name == "English")
                    {
                        DatagridData = studentsenglish;
                    }
                    else if (value.Name == "Math")
                    {
                        DatagridData = studentsmath;

                    }
                    
                    else
                    {
                        DatagridData = new List<Students>();
                    }
                    OnPropertyChanged("DatagridData");
                }
                catch (NullReferenceException)
                {
                }

            }
        }
        #endregion
        #region Methods
        public void BackTofirst(Object parameter)
        {
            First_Window mw  = new First_Window();
            mw.Show();
            
        }
        public bool CanBackTofirst(Object parameter)

        {
            return true;
        }
     
       
    
     
        #endregion
    }
}
