using HR.Entity;
using System;
using System.Collections.Generic;

namespace HR.Models
{
    public class GetCustomer
    {

        public string Firstname { get; set; }


        public string Lastname { get; set; }


        public int GenderId { get; set; }


        public string GenderName { get; set; }

       // public string Phone { get; set; }


        public DateTime DateOfBirth { get; set; }

        public List<PhoneNumberModel> PhoneNumbers { get; set; }

        

    }

    public class PhoneNumberModel
    {
     public string PhoneNumber { get; set; }
        public bool IsDefault { get; set; }
    } 
}
