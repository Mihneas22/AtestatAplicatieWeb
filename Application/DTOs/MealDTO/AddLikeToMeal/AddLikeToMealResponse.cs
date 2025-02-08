using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.MealDTO.AddLikeToMeal
{
    public record AddLikeToMealResponse(bool Flag, string message = null!);
}
