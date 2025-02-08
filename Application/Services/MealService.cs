using Application.DTOs.FoodDTO.GetFoodByName;
using Application.DTOs.MealDTO.AddLikeToMeal;
using Application.DTOs.MealDTO.GetMealByName;
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

        public async Task<GetMealByNameResponse> GetMealByNameService(GetMealByNameDTO getMealByNameDTO)
        {
            var conn = await _httpClient.GetAsync($"api/meal/getMealByName/{getMealByNameDTO.Name}");
            var result = await conn.Content.ReadFromJsonAsync<GetMealByNameResponse>();

            return result!;
        }

        public async Task<AddLikeToMealResponse> AddLikeToMealService(AddLikeToMealDTO addLikeToMealDTO)
        {
            var conn = await _httpClient.PostAsJsonAsync("api/meal/addLikeToMeal",addLikeToMealDTO);
            var result = await conn.Content.ReadFromJsonAsync<AddLikeToMealResponse>();

            return result!;
        }
    }
}
