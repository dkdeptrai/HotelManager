using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerLibrary.Models
{
    public class StaffModel
    {
        public int StaffID { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string PhoneNum { get; set; }
        public string HomeAdress { get; set; }
        public string LoginID { get; set; }
        public string Password { get; set; }
        public StaffModel()
        {

        }
        public StaffModel(string fullName, string gender, string position, string email, string phoneNum, string homeAdress, string loginID, string password)
        {
            FullName=fullName;
            Gender=gender;
            Position=position;
            Email=email;
            PhoneNum=phoneNum;
            HomeAdress=homeAdress;
            LoginID=loginID;
            Password=password;
        }
    }
}
