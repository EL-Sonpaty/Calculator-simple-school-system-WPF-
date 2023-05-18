using School_System.Models;
using School_System.ViewModel;
using School_System.View;
using School_System.Commands;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace School_System
{
    
    public partial class First_Window : Window
    {
        public First_Window()
        {
            InitializeComponent();
            TeachersViewModel teacher = new TeachersViewModel();
            this.DataContext = teacher;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SAVE.Visibility = Visibility.Visible;
            Upload.Visibility = Visibility.Visible;

        }

        private void SAVE_Click(object sender, RoutedEventArgs e)
        {
            Upload.Visibility = Visibility.Hidden;
            SAVE.Visibility = Visibility.Hidden;
        }

        private void next(object sender, RoutedEventArgs e)
        {

            Second_Window sw = new Second_Window();
            sw.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
