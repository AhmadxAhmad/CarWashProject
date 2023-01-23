using CarWash.Api.Data;
using CarWash.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Api.Repositories
{
    public class InfoRepository
    {
        private readonly DatabaseContext _context;

        public InfoRepository(DatabaseContext context) 
        {
            _context = context;
        }

        public async Task<string?> GetCategoryName(int catId)
        {
            var found = await _context.Products.Where(x => x.CategoryId == catId).Include(y=>y.Category).FirstOrDefaultAsync();
            return found?.Category.CategoryTitle;
        }
    }
}
