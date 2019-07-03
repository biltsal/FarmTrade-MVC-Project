using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmTradeFinal.Models
{
    public class UserAccount
    {
        public int ID { get; set; }
        //public int UserID { get; set; }
        public int TaxNumber { get; set; }
        public DateTime DateAccountCreated { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        public bool IsBanned { get; set; }
        public string RoleID { get; set; }

        public UserAccount()
        {
            DateAccountCreated = DateTime.Now;
        }





    }
}