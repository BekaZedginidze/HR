using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;

namespace HR.Entity
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public string Email { get; set; }   
        public DateTime CreateOnDate { get; set; }

        public bool IsActive { get; set; }
    }
}
