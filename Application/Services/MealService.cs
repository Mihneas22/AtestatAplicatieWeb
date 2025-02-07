using Application.DTOs.MealDTO.GetRandomMeal;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MealService : IMealService
    {
        private readonly HttpClient _httpClient;

        public MealService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetRandomMealResponse> GetRandomMealService()
        {
            var conn = await _httpClient.GetAsync("api/meal/getRandomMeal");
            var result = await conn.Content.ReadFromJsonAsync<GetRandomMealResponse>();

            return result!;
        }
    }
}
