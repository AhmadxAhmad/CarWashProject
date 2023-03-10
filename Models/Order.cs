using System.ComponentModel.DataAnnotations;

namespace CarWash.Api.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public string BookingId { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        [Required]
        public DateTime BookingDate { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }

        [Required]
        public bool IsCanceled { get; set; } = false;
        [Required]
        public bool IsDone { get; set; } = false;


        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}
