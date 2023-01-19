using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public int? DiscountPrice { get; set; }
        public DateTime? DiscountExpireDate { get; set; }
        public int Price { get; set; }
        public bool Status { get; set; }


        public Category? Category { get; set; }
        public int CategoryId { get; set; }



    }
}
