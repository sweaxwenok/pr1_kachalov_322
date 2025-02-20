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

namespace pr1_kachalov_322
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double x = double.Parse(InputX.Text);
                double y = double.Parse(InputY.Text);
                double result = 0;

                // Вычисляем f(x) в зависимости от выбранной функции
                double f_x = 0;
                if (RadioShX.IsChecked == true)
                {
                    f_x = Math.Sinh(x); // Гиперболический синус
                }
                else if (RadioX2.IsChecked == true)
                {
                    f_x = Math.Pow(x, 2); // Квадрат
                }
                else if (RadioExpX.IsChecked == true)
                {
                    f_x = Math.Exp(x); // Экспонента
                }

                // Вычисляем d в зависимости от условий
                if (x > y)
                {
                    result = Math.Pow(f_x - y, 3) + Math.Atan(f_x);
                }
                else if (y > x)
                {
                    result = Math.Pow(y - f_x, 3) + Math.Atan(f_x);
                }
                else if (y == x)
                {
                    result = Math.Pow(y + f_x, 3) + 0.5;
                }

                OutputResult.Text = result.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректные значения для x и y.");
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            InputX.Text = "";
            InputY.Text = "";
            OutputResult.Text = "";
            RadioShX.IsChecked = false;
            RadioX2.IsChecked = false;
            RadioExpX.IsChecked = false;
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
