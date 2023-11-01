using HR.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR.Entity
{
    [Table("Customers")]

    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string Firstname { get; set; }


        public string Lastname { get; set; }


        public int GenderId { get; set; }


        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public List<PhoneNumbers> PhoneNumbers { get; set; }


       



    }
    public class CustomerMap
    {
        public CustomerMap(EntityTypeBuilder<Customer> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Firstname).IsRequired();
            entityBuilder.Property(t => t.Lastname).IsRequired();
            entityBuilder.Property(t => t.GenderId).IsRequired();
            entityBuilder.Property(t => t.DateOfBirth).IsRequired();

        }
    }
}
