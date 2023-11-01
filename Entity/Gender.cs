using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HR.Entity
{
    public class Gender
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Customer> Customers { get; set; }    
    }
}
