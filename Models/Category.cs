

using System.ComponentModel.DataAnnotations;

namespace CarWash.Api.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryTitle { get; set; }
        public string Description { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}