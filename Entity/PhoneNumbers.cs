using System.ComponentModel.DataAnnotations;

namespace HR.Entity
{
    public class PhoneNumbers
    {
        [Key]
        public int PhoneId { get; set; }


        public int CustomerId { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDefault { get; set; }

        public Customer Customer { get; set; }
    }
}
