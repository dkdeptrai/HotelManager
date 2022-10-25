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
using System.Drawing;
using Microsoft.Win32;
using System.IO;
namespace Hotel.UI
{
    /// <summary>
    /// Interaction logic for AddRoom.xaml
    /// </summary>
    public partial class AddRoom : Window
    {
        public BitmapImage bitmapImage;
        public AddRoom()
        {
            InitializeComponent();
            IDataConnection db = GlobalConfig.Connection;
            var Choices = db.GetRoomTypes();
            TxtRoomType.ItemsSource = Choices;
        }

        //private void RoomsView_Loaded(object sender, RoutedEventArgs e)
        //{
        //    IDataConnection db = GlobalConfig.Connection;
        //    RoomsView.ItemsSource = db.GetAllRooms();
        //}

        private void BtnAddRoom_Click(object sender, RoutedEventArgs e)
        {
            if (InputValidation())
            {
                byte[] imgData = new byte[bitmapImage.StreamSource.Length];
                bitmapImage.StreamSource.Seek(0, SeekOrigin.Begin);
                bitmapImage.StreamSource.Read(imgData, 0, imgData.Length);
                
                
                RoomModel model = new RoomModel(
                    TxtRoomNum.Text,
                    TxtRoomType.Text,
                    RoomPrice.Text,
                    imgData);

                IDataConnection db = GlobalConfig.Connection;
                try
                {
                    if(db.CreateRoom(model) != null)
                    {
                        MessageBox.Show("Room Added Successfuly!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        ClearFields();
                        //RoomsView_Loaded(this, null);
                    }
                    else
                    {
                        MessageBox.Show("Room Num existed! Please try again!", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                

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
        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnAddImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.Multiselect = false;
            OpenFile.Title = "Select Picture(s)";
            OpenFile.Filter = "ALL supported Graphics| *.jpeg; *.jpg;*.png;";
            if (OpenFile.ShowDialog() == true)
            {
                bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = new FileStream(OpenFile.FileName, FileMode.Open, FileAccess.Read);    
                bitmapImage.EndInit();
                BtnAddImage.ImageSource = bitmapImage;
            }
        }
    }
}
