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

namespace Hotel.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> featureTabs = new List<string>() { "ROOMS", "SERVICES", "CHECK OUT", "REPORT" };
        public MainWindow()
        {
            InitializeComponent();
            lvTab.ItemsSource = featureTabs;
            lTime.Content = DateTime.Now.ToString("HH:mm");
            tbxDate.Text = DateTime.Now.ToString("ddd, dd/MM/yy");

            lvTab.SelectionChanged += LvTab_SelectionChanged;
        }
        private void LvTab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (lvTab.SelectedItem.ToString() == "ROOMS")
            //{
            //    DataContext = new RoomsModel();
            //}
            //else if (lvTab.SelectedItem.ToString() == "SERVICES")
            //{
            //    DataContext = new ServicesModel();
            //}
            //else if (lvTab.SelectedItem.ToString() == "CHECK OUT")
            //{
            //    DataContext = new CheckOutModel();
            //}
            //else if (lvTab.SelectedItem.ToString() == "REPORT")
            //{
            //    DataContext = new ReportModel();
            //}
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void ButtonCLose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
