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
using System.Windows.Threading;

namespace Services
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


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            else
                this.WindowState = WindowState.Maximized;
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            //Mở form AddService
            MessageBox.Show("Added!");
        }

        private void Button_Click_Report(object sender, RoutedEventArgs e)
        {
            //Mở form Report
            MessageBox.Show("Reported!");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> ViewList = new List<string>() {"Grid","Map"};
            cbView.ItemsSource = ViewList;
            List<long> PriceList = new List<long>() {0,50,100,200,300,400,500};
            cbPrice.ItemsSource = PriceList;
            List<string> TypeList = new List<string>() {"Food","Laundry","Beverage","..."};
            cbType.ItemsSource = TypeList;

        }
    }
}
