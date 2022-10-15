using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerLibrary.Models
{
    public class ServiceOrderModel
    {
        public int OrderID { get; set; }
        public int BookingID { get; set; }
        public int ServiceID { get; set; }
        public int Quantity { get; set; }
        public Decimal TotalCost { get; set; }
        public ServiceOrderModel()
        {

        }
        public ServiceOrderModel(int orderID, int bookingID, int serviceID, int quantity, decimal totalCost)
        {
            OrderID=orderID;
            BookingID=bookingID;
            ServiceID=serviceID;
            Quantity=quantity;
            TotalCost=totalCost;
        }
    }
}
