using Dapper;
using HotelManagerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerLibrary.DataAccess
{
    public class SqlConnector : IDataConnection
    {
        /// <summary>
        /// Saves a new room to the Database
        /// </summary>
        /// <param name="model">Room info</param>
        /// <returns>Room info</returns>
        public RoomModel CreateRoom(RoomModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("Hotel")))
            {
                var p = new DynamicParameters();
                p.Add("@RoomNum", model.RoomNum);
                p.Add("@RoomType", model.RoomType);
                p.Add("@Price", model.Price);
                try
                {
                    connection.Execute("dbo.spRooms_Insert", p, commandType: CommandType.StoredProcedure);

                }
                catch (Exception ex)
                {
                    throw; 
                }
            }
            return model;
        }

        public void DeleteRoom(string RoomNum)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("Hotel")))
            {
                var p = new DynamicParameters();
                p.Add("@RoomNum", RoomNum);
                connection.Execute("dbo.spRooms_Delete", p, commandType: CommandType.StoredProcedure);
            }

        }

        public List<RoomModel> GetAllRooms()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("Hotel")))
            {
                List<RoomModel> rooms = new List<RoomModel>();
                return connection.Query<RoomModel>("SELECT RoomID, RoomNum, RoomType, Price, Booked FROM Rooms").ToList();
            }
        }
        public StaffModel CreateStaff(StaffModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("Hotel")))
            {
                var p = new DynamicParameters();
                p.Add("@FullName", model.FullName);
                p.Add("@Gender", model.Gender);
                p.Add("@Position", model.Position);
                p.Add("@Email", model.Email);
                p.Add("@PhoneNum", model.PhoneNum);
                p.Add("@HomeAddress", model.HomeAdress);
                p.Add("@LoginID", model.LoginID);
                p.Add("@Password", model.Password);
                connection.Execute("dbo.spStaffs_Insert", p, commandType: CommandType.StoredProcedure);
            }
            return model;
        }

        public List<StaffModel> GetAllStaffs()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("Hotel")))
            {
                List<StaffModel> staffs = new List<StaffModel>();
                return connection.Query<StaffModel>("SELECT * FROM Staffs").ToList();
            }
        }
    }
}