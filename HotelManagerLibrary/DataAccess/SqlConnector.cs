using Dapper;
using HotelManagerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
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
                p.Add("@Overview", model.Overview);
                try
                {
                    if(!CheckExistence("Rooms", "RoomNum", model.RoomNum))
                    {
                        connection.Execute("dbo.spRooms_Insert", p, commandType: CommandType.StoredProcedure);
                    }
                    else
                    {
                        return null;
                    }    

                }
                catch (Exception ex)
                {
                    throw; 
                }
            }
            return model;
        }

        public bool DeleteRoom(string RoomNum)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("Hotel")))
            {
                var p = new DynamicParameters();
                p.Add("@RoomNum", RoomNum);
                if(CheckExistence("Rooms", "RoomNum", RoomNum))
                {
                    connection.Execute("dbo.spRooms_Delete", p, commandType: CommandType.StoredProcedure);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public RoomModel FindRoom(string RoomNum)
        {
            RoomModel model = null;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("Hotel")))
            {
                var p = new DynamicParameters();
                p.Add("@RoomNum", RoomNum);
                if (CheckExistence("Rooms", "RoomNum", RoomNum))
                {
                    var reader = connection.ExecuteReader("dbo.spRooms_View", p, commandType: CommandType.StoredProcedure);
                    while(reader.Read())
                    {
                        model = new RoomModel();
                        model.RoomNum = reader["RoomNum"].ToString();
                        model.RoomType = reader["RoomType"].ToString();
                        model.Price = Convert.ToDecimal(reader["Price"]);
                        model.RoomType = reader["Booked"].ToString();
                        model.RoomType = reader["Booked"].ToString();
                        model.Overview = reader["Overview"] as byte[];
                    }
                }
            }
            return model;
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
                if(!CheckExistence("Staffs", "LoginID", model.LoginID))
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
                else
                {
                    return null;
                }
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

        /// <summary>
        /// Checking the existence of records in the Database
        /// 
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="Column"></param>
        /// <param name="Value"></param>
        /// <returns>bool value for records existence</returns>
        public bool CheckExistence(string TableName, string Column, string Value)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("Hotel")))
            {
                bool exists = connection.ExecuteScalar<int>( $"SELECT COUNT(1) FROM {TableName} WHERE ({Column} = '{Value}')", new { value = Value }) > 0;
                return exists;
            }
        }

        public StaffModel StaffLogin(string LoginID, string Password)
        {
            StaffModel model = null;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("Hotel")))
            {
                if (CheckExistence("Staffs", "LoginID", LoginID))
                {
                    model = new StaffModel();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Staffs WHERE LoginID = @loginID", (SqlConnection)connection);
                    cmd.Parameters.AddWithValue("@loginID", LoginID);
                    connection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    while(sqlDataReader.Read())
                    {
                        if (sqlDataReader["LoginID"].ToString() == LoginID && Password == sqlDataReader["Password"].ToString())
                        {
                            model.StaffID=(int)sqlDataReader["StaffID"];
                            model.FullName=sqlDataReader["FullName"].ToString();
                            model.Gender=sqlDataReader["Gender"].ToString();
                            model.Position=sqlDataReader["Position"].ToString();
                            model.Email=sqlDataReader["Email"].ToString();
                            model.PhoneNum=sqlDataReader["PhoneNum"].ToString();
                            model.HomeAdress=sqlDataReader["HomeAddress"].ToString();
                            model.LoginID=sqlDataReader["LoginID"].ToString();
                            model.Password=sqlDataReader["Password"].ToString();
                        }
                        else
                        {
                            connection.Close();
                            return null;
                        }
                    }
                }
            connection.Close();
            }
            return model;
        }

        public List<RoomTypeModel> GetRoomTypes()
        {
            List<RoomTypeModel> RoomTypes = new List<RoomTypeModel>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("Hotel")))
            {
                var cmd = new SqlCommand("SELECT TypeName FROM RoomTypes", (SqlConnection)connection);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    RoomTypes.Add(new RoomTypeModel(reader.GetString(0)));
                }
                connection.Close();
            }
                return RoomTypes;
        }
        public RoomTypeModel CreateRoomType(RoomTypeModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("Hotel")))
            {
                var p = new DynamicParameters();
                p.Add("@TypeName", model.TypeName);
                try
                {
                    if (!CheckExistence("RoomTypes", "TypeName", model.TypeName))
                    {
                        connection.Execute("dbo.spRoomTypes_Insert", p, commandType: CommandType.StoredProcedure);
                    }
                    else
                    {
                        return null;
                    }

                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return model;
        }
    }
}