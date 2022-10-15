using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerLibrary.Models
{
    internal class BillModel
    {
        public int BillID { get; set; }
        public int CustomerID { get; set; }
        public int StaffID { get; set; }
        public int BookingID { get; set; }
        public Decimal TotalCost { get; set; }
        public BillModel()
        {

        }
        public BillModel(int billID, int customerID, int staffID, int bookingID, decimal totalCost)
        {
            BillID=billID;
            CustomerID=customerID;
            StaffID=staffID;
            BookingID=bookingID;
            TotalCost=totalCost;
        }
    }
}
