using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerLibrary.Models
{
    public class RoomTypeModel
    {
        public int TypeID { get; set; }
        public string TypeName { get; set; }
        public RoomTypeModel()
        {

        }
        public RoomTypeModel(string typeName)
        {
            TypeName=typeName;
        }
        public override string ToString()
        {
            return TypeName;
        }
    }

}
