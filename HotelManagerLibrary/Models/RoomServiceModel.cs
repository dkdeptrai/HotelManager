using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerLibrary.Models
{
    public class RoomServiceModel
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public Decimal Price { get; set; }
        public RoomServiceModel()
        {

        }
        public RoomServiceModel(int serviceID, string serviceName, decimal price)
        {
            ServiceID=serviceID;
            ServiceName=serviceName;
            Price=price;
        }

    }
}
