using AutoMapper;
using CarWash.Api.Models;
using CarWash.ViewModels;

namespace CarWash.Api.Profiles
{
    public class AppProfiles:Profile
    {
        public AppProfiles()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CategoryViewModel, Category>();

            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();

   
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<CustomerViewModel, Customer>();


            CreateMap<Order, OrderViewModel>();
            CreateMap<OrderViewModel, Order>();


        }
    }
}
