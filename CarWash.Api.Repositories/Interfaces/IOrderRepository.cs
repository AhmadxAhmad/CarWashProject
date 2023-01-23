using CarWash.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CarWash.Api.Repositories
{
    public interface IOrderRepository
    {
        Task<int> AddItem(Order Item);
        Task<bool> CheckBookingId(string bId);
        Task<bool> SaveAsync();
    }
}