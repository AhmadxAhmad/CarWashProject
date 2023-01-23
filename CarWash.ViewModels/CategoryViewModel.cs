using System.ComponentModel.DataAnnotations;

namespace CarWash.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        [Required]
        public string CategoryTitle { get; set; }
        public string Description { get; set; }

        public ICollection<ProductViewModel>? Products { get; set; }
    }
}