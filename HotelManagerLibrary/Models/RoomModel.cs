using System;
using System.Collections.Generic;
using System.Data;
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
        public byte[] Overview { get; set; }

        public RoomModel()
        {

        }

        public RoomModel(string roomNum, string roomType, string price, byte[] overview)
        {
            RoomNum = roomNum;
            RoomType = roomType;
            Price = decimal.Parse(price);
            Booked = "NO";
            Overview = overview;
        }
    }

}

