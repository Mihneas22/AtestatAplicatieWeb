using Application.DTOs.FoodDTO.AddFood;
using Application.DTOs.FoodDTO.GetFoodByName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public interface IFood
    {
        Task<AddFoodResponse> AddFoodAsync(AddFoodDTO addFoodDTO);

        Task<GetFoodByNameResponse> GetFoodByNameAsync(GetFoodByNameDTO getFoodByNameDTO);
    }
}
