using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Order
    {
        public int Id { get; set; }

        public Product? Product { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public Receipt? Receipt { get; set; }
        public int ReceiptId { get; set; }
    }
}
