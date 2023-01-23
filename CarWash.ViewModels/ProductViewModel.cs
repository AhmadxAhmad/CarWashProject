using System.ComponentModel.DataAnnotations;

namespace CarWash.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        [Required]
        public string ProductTitle { get; set; }

        public string ProductDescription { get; set; }

        public int ProductTime { get; set; }

        public int? DiscountPrice { get; set; }
        public DateTime? DiscountExpireDate { get; set; }
        public int Price { get; set; }
        public bool Status { get; set; }

        public string? CategoryName { get; set; }
        public int CategoryId { get; set; }


    }
}
