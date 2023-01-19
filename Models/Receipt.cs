using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Receipt
    {
        [Key]
        public int Id { get; set; }

        public string BookingId { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public DateTime ReceiptDate { get; set; }

        public ICollection<Order>? Orders { get; set; }

        public bool IsPaid { get; set; }

        public Customer? Customer { get; set; }
        public int CustomerId { get; set; }

    }
}
