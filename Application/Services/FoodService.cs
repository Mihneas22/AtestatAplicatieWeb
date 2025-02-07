using Application.DTOs.FoodDTO.GetFoodByName;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FoodService : IFoodService
    {
        private readonly HttpClient _httpClient;

        public FoodService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetFoodByNameResponse> GetFoodByNameAsync(GetFoodByNameDTO getFoodByNameDTO)
        {
            var conn = await _httpClient.GetAsync($"api/food/getFoodByName/{getFoodByNameDTO.Name}");
            var result = await conn.Content.ReadFromJsonAsync<GetFoodByNameResponse>();

            return result!;
        }
    }
}
