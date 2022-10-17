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

namespace Hotel.UI
{
    /// <summary>
    /// Interaction logic for DeleteRoom.xaml
    /// </summary>
    public partial class DeleteRoom : Window
    {
        public DeleteRoom()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (InputValidation())
            {
                IDataConnection db = GlobalConfig.Connection;
                try
                {
                    db.DeleteRoom(TxtRoomNum.Text);
                }
                catch (Exception)
                {

                    throw;
                }
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
    }
}
