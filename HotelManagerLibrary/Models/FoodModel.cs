using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerLibrary.Models
{
    public class FoodModel
    {
        public int FoodID { get; set; }
        public string FoodName { get; set; }
        public Decimal FoodPrice { get; set; }
        public byte[] FoodImage { get; set; }
        public FoodModel()
        {

        }

        public FoodModel(string foodName, decimal foodPrice, byte[] foodImage)
        {
            FoodName=foodName;
            FoodPrice=foodPrice;
            FoodImage=foodImage;
        }
    }
}
