using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.MealDTO.SaveMeal
{
    public record SaveMealResponse(bool Flag, string message = null!);
}
