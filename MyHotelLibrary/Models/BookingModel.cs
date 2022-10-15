using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerLibrary.Models
{
    public class BookingModel
    {
        public int BookingID { get; set; }
        public int CustomerID { get; set; }
        public int RoomID { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public BookingModel()
        {

        }
        public BookingModel(int bookingID, int customerID, int roomID, DateTime checkInTime, DateTime checkOutTime)
        {
            BookingID=bookingID;
            CustomerID=customerID;
            RoomID=roomID;
            CheckInTime=checkInTime;
            CheckOutTime=checkOutTime;
        }
    }
}
