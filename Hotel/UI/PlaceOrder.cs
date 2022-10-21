using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Da them thanh cong");
        }

        private void Placing_Orther_Loaded(object sender, RoutedEventArgs e)
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
    }
}
