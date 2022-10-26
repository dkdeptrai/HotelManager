using HotelManagerLibrary.DataAccess;
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
using HotelManagerLibrary.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Hotel.UI
{
    /// <summary>
    /// Interaction logic for FindRoom.xaml
    /// </summary>
    public partial class FindRoom : Window
    {
        public FindRoom()
        {
            InitializeComponent();
        }

        private void BtnFind_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            if (InputValidation())
            {
                IDataConnection db = GlobalConfig.Connection;
                try
                {
                    RoomModel FetchedModel = db.FindRoom(TxtRoomNum.Text);
                    if(FetchedModel != null)
                    {
                        TxtBlockRoomNum.Text = FetchedModel.RoomNum;
                        TxtBlockRoomType.Text = FetchedModel.RoomType;
                        TxtBlockRoomPrice.Text = FetchedModel.Price.ToString();
                        TxtBlockRoomStatus.Text = FetchedModel.Booked;
                        System.IO.MemoryStream ms = new System.IO.MemoryStream(FetchedModel.Overview);
                        ms.Seek(0, System.IO.SeekOrigin.Begin);
                        BitmapImage newBitmapImage = new BitmapImage();

                        newBitmapImage.BeginInit();

                        newBitmapImage.StreamSource = ms;
                        newBitmapImage.EndInit();

                        OverviewImage.ImageSource = newBitmapImage;

                        BtnDeleteRoom.IsEnabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Room not found, try again!", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                MessageBox.Show("Please Enter Room Number!", "Room Number Not Entered!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool InputValidation()
        {
            bool output = true;
            if (TxtRoomNum.Text == "")
            {
                output = false;
            }
            return output;
        }
        
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnDeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            if (InputValidation())
            {
                IDataConnection db = GlobalConfig.Connection;
                try
                {
                    if (db.DeleteRoom(TxtRoomNum.Text))
                    {
                        MessageBox.Show("Room deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Room not found, try again!", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                MessageBox.Show("Please Enter Room Number!", "Room Number Not Entered!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            InitializeComponent();
        }
    }
}
