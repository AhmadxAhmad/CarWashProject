using CarWash.Api.Data;
using CarWash.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CarWash.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly ILogger<ProductRepository> _logger;
        private readonly DatabaseContext _context;


        public ProductRepository(ILogger<ProductRepository> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<IEnumerable<Product>?> GetAll() => await _context.Products.ToListAsync();

        public async Task<bool> AddItem(Product Item)
        {
            var found = await _context.Products.Where(x => x.ProductTitle == Item.ProductTitle).FirstOrDefaultAsync();
            if (found is null)
            {
                _context.Add(Item);
                return true;
            }
            return false;

        }
        public async Task<Product?> GetById(int id) => await _context.Products.Where(x => x.ProductId == id).FirstOrDefaultAsync();
        public async Task<bool> SaveAsync() => await _context.SaveChangesAsync() >= 1 ? true : false;
        public async Task RemoveItem(Product item) => _context.Products.Remove(item);
    }
}
