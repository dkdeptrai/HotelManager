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

namespace Placing_order
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Da them thanh cong");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<int> DayList = new List<int>();
            for (int i = 1; i <= 31; i++)
            {
                DayList.Add(i);
            }
            cbDay.ItemsSource = DayList;
            List<int> MonthList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            cbMonth.ItemsSource = MonthList;
            List<int> YearList = new List<int>();
            for (int i = 1992; i <= 2022; i++)
            {
                YearList.Add(i);
            }
            cbYear.ItemsSource = YearList;
        }

        private void quantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (quantity.Text == "")
                quantity.Text = "0";
            total.Content = int.Parse((string)price.Content) * int.Parse(quantity.Text);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if(this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            else
                this.WindowState = WindowState.Maximized;
            
        }
    }
}
