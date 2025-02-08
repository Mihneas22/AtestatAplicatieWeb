using Application.DTOs.MealDTO.AddLikeToMeal;
using Application.DTOs.MealDTO.GetMealByName;
using Application.DTOs.MealDTO.GetRandomMeal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IMealService
    {
        Task<GetRandomMealResponse> GetRandomMealService();

        Task<GetMealByNameResponse> GetMealByNameService(GetMealByNameDTO getMealByNameDTO);
    
        Task<AddLikeToMealResponse> AddLikeToMealService(AddLikeToMealDTO addLikeToMealDTO);
    }
}
