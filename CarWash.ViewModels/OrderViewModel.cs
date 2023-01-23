using System.ComponentModel.DataAnnotations;

namespace CarWash.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        [Required]
        public string BookingId { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BookingDate { get; set; }
        [Required]
        public bool IsCanceled { get; set; } = false;
        [Required]
        public bool IsDone { get; set; } = false;

        public string? CustomerName { get; set; }
        [Required]
        public int CustomerId { get; set; }

        public string? ProductTitle { get; set; }
        [Required]
        public int ProductId { get; set; }


    }
}
