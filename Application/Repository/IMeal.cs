using Application.DTOs.MealDTO.AddLikeToMeal;
using Application.DTOs.MealDTO.AddMeal;
using Application.DTOs.MealDTO.GetMealByName;
using Application.DTOs.MealDTO.GetRandomMeal;
using Application.DTOs.MealDTO.SaveMeal;

namespace Application.Repository
{
    public interface IMeal
    {
        Task<AddMealResponse> AddMealAsync(AddMealDTO addMealDTO);

        Task<GetRandomMealResponse> GetRandomMealAsync();

        Task<GetMealByNameResponse> GetMealByNameAsync(GetMealByNameDTO getMealByNameDTO);

        Task<AddLikeToMealResponse> AddLikeToMealAsync(AddLikeToMealDTO addLikeToMealDTO);

        Task<SaveMealResponse> SaveMealAsync(SaveMealDTO saveMealDTO);
    }
}
