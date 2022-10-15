using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerLibrary.Models
{
    public class RoomModel
    {
        public System.Int32 RoomID { get; }
        public string RoomNum { get; set; }
        public string RoomType { get; set; }
        public Decimal Price { get; set; }
        public string Booked { get; set; }

        public RoomModel()
        {

        }

        public RoomModel(string roomNum, string roomType, string price)
        {
            RoomNum = roomNum;
            RoomType = roomType;
            Price = decimal.Parse(price);
            Booked = "NO";
        }
    }

}

