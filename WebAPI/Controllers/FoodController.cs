using Application.DTOs.FoodDTO.AddFood;
using Application.DTOs.FoodDTO.GetFoodByName;
using Application.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFood foodRepo;

        public FoodController(IFood foodRepo)
        {
            this.foodRepo = foodRepo;
        }

        [HttpPost("addFood")]
        public async Task<ActionResult<AddFoodResponse>> AddFoodAsync(AddFoodDTO addFoodDTO)
        {
            var result = await foodRepo.AddFoodAsync(addFoodDTO);
            return Ok(result!);
        }

        [HttpGet("getFoodByName")]
        public async Task<ActionResult<GetFoodByNameResponse>> GetFoodByNameAsync(GetFoodByNameDTO getFoodByNameDTO)
        {
            var result = await foodRepo.GetFoodByNameAsync(getFoodByNameDTO);
            return Ok(result!);
        }
    }
}
