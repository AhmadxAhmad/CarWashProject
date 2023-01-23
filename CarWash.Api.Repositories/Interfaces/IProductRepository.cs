using CarWash.Api.Models;

namespace CarWash.Api.Repositories
{
    public interface IProductRepository
    {
        Task<bool> AddItem(Product Item);
        Task<IEnumerable<Product>?> GetAll();
        Task<Product?> GetById(int id);
        Task RemoveItem(Product item);
        Task<bool> SaveAsync();
    }
}