using School_System.Models;
using School_System.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace School_System.View
{
    
    public partial class Second_Window : Window
    {
        public Second_Window()
        {
            InitializeComponent();
             SubjectsViewModel svm = new SubjectsViewModel();
            this.DataContext = svm;    
        }

        private void back(object sender, RoutedEventArgs e)
        {
            First_Window mw = new First_Window();
            mw.Show();
            this.Close();
        }
    }
}
