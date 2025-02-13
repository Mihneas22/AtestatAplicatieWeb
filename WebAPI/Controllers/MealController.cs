using Application.DTOs.MealDTO.AddLikeToMeal;
using Application.DTOs.MealDTO.AddMeal;
using Application.DTOs.MealDTO.GetMealByName;
using Application.DTOs.MealDTO.GetRandomMeal;
using Application.DTOs.MealDTO.SaveMeal;
using Application.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly IMeal mealRepo;

        public MealController(IMeal mealRepo)
        {
            this.mealRepo = mealRepo;
        }

        [HttpPost("addMeal")]
        public async Task<ActionResult<AddMealResponse>> AddMealAsync(AddMealDTO addMealDTO)
        {
            var result = await mealRepo.AddMealAsync(addMealDTO);
            return Ok(result);
        }

        [HttpPost("addLikeToMeal")]
        public async Task<ActionResult<AddLikeToMealResponse>> AddLikeToMealAsync(AddLikeToMealDTO addLikeToMealDTO)
        {
            var result = await mealRepo.AddLikeToMealAsync(addLikeToMealDTO);
            return Ok(result);
        }

        [HttpPost("saveMeal")]
        public async Task<ActionResult<SaveMealResponse>> SaveMealAsync(SaveMealDTO saveMealDTO)
        {
            var result = await mealRepo.SaveMealAsync(saveMealDTO);
            return Ok(result);
        }

        [HttpGet("getRandomMeal")]
        public async Task<ActionResult<GetRandomMealResponse>> GetRandomMealAsync()
        {
            var result = await mealRepo.GetRandomMealAsync();
            return Ok(result);
        }

        [HttpGet("getMealByName/{name}")]
        public async Task<ActionResult<GetMealByNameResponse>> GetMealByNameAsync(string name)
        {
            var result = await mealRepo.GetMealByNameAsync(new GetMealByNameDTO { Name = name });
            return Ok(result);
        }
    }
}
