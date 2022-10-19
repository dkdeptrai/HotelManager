using HotelManagerLibrary;
using HotelManagerLibrary.DataAccess;
using HotelManagerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace Hotel.UI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string loginID = TxtLoginID.Text;
            string password = TxtPassword.Password.ToString();
            if(InputValidation())
            {
                IDataConnection db = GlobalConfig.Connection;
                StaffModel LoginUser = db.StaffLogin(loginID, password);
                if(LoginUser != null)
                {
                    App.CurrentUser = LoginUser;
                    MessageBox.Show("Login successfully!", "Logged in", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Incorrect LoginID or Password!", "Login failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("At least one field is invalid!", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private bool InputValidation()
        {
            bool result = true;
            if(TxtLoginID.Text == "" || TxtPassword.Password.ToString() == "")
            {
                result = false;
            }
            return result;
        }
    }
}
