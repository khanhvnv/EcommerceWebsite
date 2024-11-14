using System;
using System.Net.Http.Json;
using EcommerceShared.Models;

namespace EcommerceCustomer.Services
{
    public class CategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<List<Category>> GetCategoriesAsync() =>
            await _httpClient.GetFromJsonAsync<List<Category>>("/api/category");
    }

}