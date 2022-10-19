using Hotel.UI;
using HotelManagerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static StaffModel CurrentUser;
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            HotelManagerLibrary.GlobalConfig.InitializeConnection();
            Login window = new Login();
            window.Show();
        }
    }
}
