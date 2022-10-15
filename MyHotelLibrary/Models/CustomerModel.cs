using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerLibrary.Models
{
    public class CustomerModel
    {
        public int CustomerID { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string IdNumber { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string HomeAddress { get; set; }

        public CustomerModel()
        {
            
        }
        public CustomerModel(int customerID, string fullName, string gender, string idNumber, DateTime birthday, string email, string phoneNumber, string homeAddress)
        {
            CustomerID=customerID;
            FullName=fullName;
            Gender=gender;
            IdNumber=idNumber;
            Birthday=birthday;
            Email=email;
            PhoneNumber=phoneNumber;
            HomeAddress=homeAddress;
        }
    }
}
