using HotelManagerLibrary;
using HotelManagerLibrary.DataAccess;
using HotelManagerLibrary.Models;
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
    /// Interaction logic for AddRoomType.xaml
    /// </summary>
    public partial class AddRoomType : Window
    {
        public AddRoomType()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IDataConnection db = GlobalConfig.Connection;
            RoomTypeModel model = new RoomTypeModel(TxtRoomType.Text);
            try
            {
                if(db.CreateRoomType(model) != null)
                {
                    MessageBox.Show("Room Type Added Successfuly!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Room Type existed! Please try again!", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void ClearFields()
        {
            TxtRoomType.Text = "";
        }
    }
}
