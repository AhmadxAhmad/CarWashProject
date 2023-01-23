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
    public class CategoryRepository : ICategoryRepository
    {

        private readonly ILogger<CategoryRepository> _logger;
        private readonly DatabaseContext _context;


        public CategoryRepository(ILogger<CategoryRepository> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;

        }
        public async Task<IEnumerable<Category>?> GetAll() => await _context.Categories.Include(x => x.Products).ToListAsync();

        public async Task<bool> AddItem(Category Item)
        {
            var found = await _context.Categories.Where(x => x.CategoryTitle == Item.CategoryTitle).FirstOrDefaultAsync();
            if (found is null)
            {
                _context.Add(Item);
                return true;
            }
            return false;

        }
        public async Task<Category?> GetById(int id) => await _context.Categories.Where(x => x.CategoryId == id).FirstOrDefaultAsync();
        public async Task<bool> SaveAsync() => await _context.SaveChangesAsync() >= 1 ? true : false;
        public async Task RemoveItem(Category item) => _context.Categories.Remove(item);
    }
}
