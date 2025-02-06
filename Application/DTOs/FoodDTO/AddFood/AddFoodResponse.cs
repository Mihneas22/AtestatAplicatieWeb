using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.FoodDTO.AddFood
{
    public record AddFoodResponse(bool Flag, string message = null!);
}
