using HR.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HR.Models
{
    public class InsertCustomer
    {

            public string Firstname { get; set; }


            public string Lastname { get; set; }


            public int GenderId { get; set; }

            public DateTime DateOfBirth { get; set; }


             public List<InsertPhoneNumber> PhoneNumbers { get; set; }







    }

    public class InsertPhoneNumber
    {
       
        public string PhoneNumber { get; set;}

        public bool IsDefault { get; set; }
    }
}
