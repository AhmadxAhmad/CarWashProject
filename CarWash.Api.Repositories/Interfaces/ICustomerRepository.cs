using CarWash.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CarWash.Api.Repositories
{
    public interface ICustomerRepository
    {
        Task<int> AddItem(Customer Item);
        Task<bool> SaveAsync();
    }
}