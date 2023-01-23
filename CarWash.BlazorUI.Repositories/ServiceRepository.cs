using CarWash.ViewModels;
using System.Net.Http.Json;

namespace CarWash.BlazorUI.Repositories
{
    public class ServiceRepository
    {
        private readonly HttpClient _httpClient;

        public ServiceRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategories()
        {
            var responseMessage = await _httpClient.GetAsync("https://localhost:7084/api/category/GetAllCategories");
            var response = await responseMessage.Content.ReadFromJsonAsync<IEnumerable<CategoryViewModel>>();
            return response;
        }

        public async Task<int> CreateCustomer(CustomerViewModel customer)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync("https://localhost:7084/api/Customer/AddCustomer", customer);
            var response = await responseMessage.Content.ReadFromJsonAsync<int>();
            return response;
        }
        public async Task<bool> CheckBookingId(string bId)
        {
            var responseMessage = await _httpClient.GetAsync($"https://localhost:7084/api/Order/CheckBookingId/{bId}");
            var response = await responseMessage.Content.ReadAsStringAsync();
            if (response == "true")
            {
                return true;
            }
            return false;

        }
        public async Task<bool> MakeOrder(OrderViewModel order)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync("https://localhost:7084/api/Order/AddOrder", order);
            var response = await responseMessage.Content.ReadFromJsonAsync<bool>();
            return response;
        }
    }
}
