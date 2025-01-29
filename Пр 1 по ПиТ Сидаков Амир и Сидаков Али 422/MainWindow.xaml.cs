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

namespace Пр_1_по_ПиТ_Сидаков_Амир_и_Сидаков_Али_422
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
                double x = double.Parse(TextBoxX.Text);
                double q = double.Parse(TextBoxQ.Text);
                double f_x = ComputeFunction(x);
                double result = SolveEquation(x, q, f_x);
                ResultTextBox.Text = result.ToString("F4"); // Округление до 4 знаков
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private double ComputeFunction(double x)
        {
            if (RadioShX.IsChecked == true)
                return Math.Sinh(x);
            else if (RadioX2.IsChecked == true)
                return Math.Pow(x, 2);
            else
                return Math.Exp(x);
        }

        private double SolveEquation(double x, double q, double f_x)
        {
            double product = Math.Abs(x * q);

            if (product > 10)
                return Math.Log(Math.Abs(f_x) + Math.Abs(q));
            else if (product < 10)
                return Math.Exp(f_x + q);
            else
                return f_x + q;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            TextBoxX.Clear();
            TextBoxQ.Clear();
            ResultTextBox.Clear();
        }
    }
}
