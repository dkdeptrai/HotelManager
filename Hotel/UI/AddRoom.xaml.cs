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
    /// Interaction logic for AddRoom.xaml
    /// </summary>
    public partial class AddRoom : Window
    {
        public AddRoom()
        {
            InitializeComponent();
        }

        private void RoomsView_Loaded(object sender, RoutedEventArgs e)
        {
            IDataConnection db = GlobalConfig.Connection;
            RoomsView.ItemsSource = db.GetAllRooms();
        }

        private void BtnAddRoom_Click(object sender, RoutedEventArgs e)
        {
            if (InputValidation())
            {
                RoomModel model = new RoomModel(
                    TxtRoomNum.Text,
                    TxtRoomType.Text,
                    RoomPrice.Text);

                IDataConnection db = GlobalConfig.Connection;
                try
                {
                    db.CreateRoom(model);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    BtnAddRoom_Click(this, null);
                    throw;
                }
                MessageBox.Show("Room Added Successfuly!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearFields();
                RoomsView_Loaded(this, null);

            }
            else
            {
                MessageBox.Show("At least one field is invalid!", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public bool InputValidation()
        {
            bool output = true;
            int RoomNum = 0;
            bool RoomNumValid = int.TryParse(TxtRoomNum.Text, out RoomNum);

            if (!RoomNumValid)
            {
                output = false;
            }

            if (TxtRoomNum.Text.Length == 0)
            {
                output = false;
            }

            long Price = 0;

            bool PriceValid = long.TryParse(RoomPrice.Text, out Price);

            if (!PriceValid)
            {
                output = false;
            }

            if (Price < 0)
            {
                output = false;
            }

            return output;
        }

        public void ClearFields()
        {
            TxtRoomNum.Text = "";
            TxtRoomType.Text = "";
            RoomPrice.Text = "";
        }
    }
}
