using HotelManagerLibrary.DataAccess;
using HotelManagerLibrary.Models;
using HotelManagerLibrary;
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
using System.Windows.Shapes;

namespace Hotel.UI
{
    /// <summary>
    /// Interaction logic for AddStaff.xaml
    /// </summary>
    public partial class AddStaff : Window
    {
        public AddStaff()
        {
            InitializeComponent();
        }

        private void BtnAddStaff_Click(object sender, RoutedEventArgs e)
        {
            if (InputValidation())
            {
                StaffModel model = new StaffModel(
                    TxtFullName.Text,
                    TxtGender.Text,
                    TxtPosition.Text,
                    TxtEmail.Text,
                    TxtPhoneNum.Text,
                    TxtHomeAddress.Text,
                    TxtLoginID.Text,
                    TxtPassword.Text);

                IDataConnection db = GlobalConfig.Connection;
                try
                {
                    db.CreateStaff(model);
                }
                catch (Exception ex)
                {
                    throw;
                }
                MessageBox.Show("Staff Added Successfuly!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearFields();
                StaffView_Loaded(this, null);
            }
            else
            {
                MessageBox.Show("At least one field is invalid!", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void StaffView_Loaded(object sender, RoutedEventArgs e)
        {
            IDataConnection db = GlobalConfig.Connection;
            StaffView.ItemsSource = db.GetAllStaffs();
        }

        public void ClearFields()
        {
            TxtFullName.Text = TxtGender.Text = TxtPosition.Text = TxtEmail.Text = TxtPhoneNum.Text = TxtHomeAddress.Text = TxtLoginID.Text = TxtPassword.Text = "";
        }

        public bool InputValidation()
        {
            bool result = true;
            if (TxtPhoneNum.Text.Length != 10)
            {
                result = false;
            }

            if (TxtLoginID.Text.Length == 0)
            {
                result = false;
            }

            if (TxtPassword.Text.Length == 0)
            {
                result = false;
            }
            return result;
        }
    }
}
