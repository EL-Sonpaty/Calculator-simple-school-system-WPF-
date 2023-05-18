using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using static System.Net.Mime.MediaTypeNames;

namespace Ahmed_Salah_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double First_Number = 0;
        public double Second_Number = 0;
        public double Result= 0;
        public string Screen01;
        public string Screen02;
        public string Operator;
        public string Screen00;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Digits(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Screen.Text += button.Content.ToString();
            Obtaining_First_Number(Screen.Text);
            

        }
        public void Obtaining_First_Number(string Text)
        {
            Screen00 = Text;
            Screen00 = Screen00.Replace("1/x", "");
            Screen00 = Screen00.Replace("x^2", "");
            Screen00 = Screen00.Replace("sqrt(x)", "");
            Screen00 = Screen00.Replace("÷", "");
            Screen00 = Screen00.Replace("×", "");
            Screen00 = Screen00.Replace("-", "");
            Screen00 = Screen00.Replace("+", "");
            Screen00 = Screen00.Replace("%", "");

            #region to remove the second .
            Screen00 = 
                Regex.Replace(
                            Screen00, //input string
                            @"(?<=\.).*", //match everything after 1st "."
                             m => m.Value.Replace(".", string.Empty));//return value of match without "."

            #endregion

            #region to remove text after white space
            string input = Screen00;
            int index = input.IndexOf(" ");
            if (index >=0)
                input = input.Substring(0, index);
            Screen00 = input;
            #endregion



            Screen00 = Screen00.Replace(" ", "");

            First_Number = Convert.ToDouble(Screen00);

           

        }
        public void Obtaining_Second_Number(string Text)
        {
            Screen01 =  Text;
            Screen01 = Screen01.Replace($"{First_Number}", "");
            Screen01 = Screen01.Replace("1/x", "");
            Screen01 = Screen01.Replace("x^2", "");
            Screen01 = Screen01.Replace("sqrt(x)", "");
            Screen01 = Screen01.Replace("÷", "");
            Screen01 = Screen01.Replace("×", "");
            Screen01 = Screen01.Replace("-", "");
            Screen01 = Screen01.Replace("+", "");
            Screen01 = Screen01.Replace("%", "");
            Screen01 = Screen01.Replace(" ", "");
            Second_Number = Convert.ToDouble(Screen01);
        }
        private void OP(object sender, RoutedEventArgs e)
        {
            if (sender == null)
            {
                return;
            }
            string Content = ((Button)sender).Content.ToString();
            switch (Content)
            {
                case "1/x":
                    Screen.Text = $"1/({First_Number})" ;
                    Operator ="1/x";

                    break;
                case "x^2":
                    Screen.Text = $"({First_Number})^2";
                    Operator = "x^2";
                    break;
                case "sqrt(x)":
                    Screen.Text = $"sqrt({First_Number})";
                    Operator = "sqrt(x)";
                    break;


                case "÷":
                    Screen.Text = $"{First_Number} ÷  ";
                    Operator = "÷";
                    break;
                case "×":
                    Screen.Text = $"{First_Number} × ";
                    Operator = "×";
                    break;
                case "-":
                    Screen.Text = $"{First_Number} - ";
                    Operator = "-";
                    break;
                case "+":
                    Screen.Text = $"{First_Number} + ";
                    Operator = "+";
                    break;
                case "%":
                    Screen.Text = $"{First_Number} %  ";
                    Operator = "%";
                    break;
            }
        }
        private void Equal(object sender, RoutedEventArgs e)
        {
            
            switch (Operator)
            {
                case "1/x":
                    Result = 1 / First_Number;
                    Answer.Text = Result.ToString();
                    break;
                case "x^2":
                    Result = Math.Pow(First_Number,2);
                    Answer.Text = Result.ToString();
                    break;
                case "sqrt(x)":
                    Result = Math.Sqrt(First_Number);
                    Answer.Text = Result.ToString();
                    break;

                case "÷":
                    Obtaining_Second_Number(Screen.Text);
                    Result = First_Number/Second_Number;
                    Answer.Text = Result.ToString();
                    break;

                case "×":
                    Obtaining_Second_Number(Screen.Text);
                    Result = First_Number * Second_Number;
                    Answer.Text = Result.ToString();
                    break;

                case "-":
                    Obtaining_Second_Number(Screen.Text);
                    Result = First_Number - Second_Number;
                    Answer.Text = Result.ToString();
                    break;

                case "+":
                    Obtaining_Second_Number(Screen.Text);
                    Result = First_Number + Second_Number;
                    Answer.Text = Result.ToString();
                    break;
                case "%":
                    Obtaining_Second_Number(Screen.Text);
                    Result = First_Number % Second_Number;
                    Answer.Text = Result.ToString();
                    break;


            }
        }

        private void Key04_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Screen.Text = Screen.Text.Remove(Screen.Text.Length - 1, 1);
        }

        private void Key03_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Screen.Text = null;
        }

        private void Key02_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Answer.Text = Math.Round(Result).ToString();
        }

        private void Screen_TextChanged()
        {

        }
    }
    }
