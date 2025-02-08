using Application.DTOs.FoodDTO.GetFoodByName;
using Application.DTOs.MealDTO.AddMeal;
using Application.DTOs.MealDTO.GetMealByName;
using Application.DTOs.MealDTO.GetRandomMeal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public interface IMeal
    {
        Task<AddMealResponse> AddMealAsync(AddMealDTO addMealDTO);

        Task<GetRandomMealResponse> GetRandomMealAsync();

        Task<GetMealByNameResponse> GetMealByNameAsync(GetMealByNameDTO getMealByNameDTO);
    }
}
