
using System.ComponentModel.DataAnnotations;

namespace CarWash.Api.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerEmail { get; set; }
        [Required]
        public string CustomerPhone { get; set; }
        [Required]
        public string RegNo { get; set; }

        public ICollection<Order>? Orders { get; set; }

    }
}
