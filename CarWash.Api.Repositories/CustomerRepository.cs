using CarWash.Api.Data;
using CarWash.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Api.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ILogger<CustomerRepository> _logger;
        private readonly DatabaseContext _context;


        public CustomerRepository(ILogger<CustomerRepository> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<int> AddItem(Customer Item)
        {
            var found = await _context.Customers.Where(x => x.CustomerName == Item.CustomerName).FirstOrDefaultAsync();
            if (found is null)
            {
                _context.Customers.Add(Item);

                return 0;
            }
            return found.CustomerId;
        }
        public async Task<bool> SaveAsync() => await _context.SaveChangesAsync() >= 1 ? true : false;
    }
}
