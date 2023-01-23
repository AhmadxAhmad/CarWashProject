using CarWash.Api.Data;
using CarWash.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CarWash.Api.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ILogger<OrderRepository> _logger;
        private readonly DatabaseContext _context;


        public OrderRepository(ILogger<OrderRepository> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<int> AddItem(Order Item)
        {
            var found = await _context.Orders.Where(x => x.BookingId == Item.BookingId).FirstOrDefaultAsync();
            if (found is null)
            {
                _context.Orders.Add(Item);
                return 1;
            }
            return 0;
        }

        public async Task<bool> CheckBookingId(string bId)
        {
            var found = await _context.Orders.Where(x => x.BookingId == bId).FirstOrDefaultAsync();
            if(found is null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> SaveAsync() => await _context.SaveChangesAsync() >= 1 ? true : false;
    }
}
