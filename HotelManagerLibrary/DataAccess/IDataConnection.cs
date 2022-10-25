using HotelManagerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerLibrary.DataAccess
{
    public interface IDataConnection
    {
        RoomModel CreateRoom(RoomModel model);
        RoomModel FindRoom(string RoomNum);
        bool DeleteRoom(string RoomNum);
        List<RoomModel> GetAllRooms();
        StaffModel CreateStaff(StaffModel model);
        List<StaffModel> GetAllStaffs();
        StaffModel StaffLogin(string LoginID, string Password);
        List<RoomTypeModel> GetRoomTypes();
        RoomTypeModel CreateRoomType(RoomTypeModel model);

    }
}
