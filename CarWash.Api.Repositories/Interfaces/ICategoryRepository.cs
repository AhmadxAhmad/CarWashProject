using CarWash.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CarWash.Api.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>?> GetAll();
        Task<bool> AddItem(Category Item);
        Task<bool> SaveAsync();
        Task RemoveItem(Category item);
        Task<Category?> GetById(int id);
    }
}