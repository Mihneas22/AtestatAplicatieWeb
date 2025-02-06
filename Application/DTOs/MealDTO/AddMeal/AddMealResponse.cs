using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.MealDTO.AddMeal
{
    public record AddMealResponse(bool Flag, string message = null!);
}
