using System.ComponentModel.DataAnnotations;

namespace CarWash.ViewModels
{
    public class CustomerViewModel
    {
        public int? CustomerId { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string CustomerName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string CustomerEmail { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string CustomerPhone { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(9)]
        public string RegNo { get; set; }

        public IEnumerable<OrderViewModel>? Orders { get; set; }

    }
}
