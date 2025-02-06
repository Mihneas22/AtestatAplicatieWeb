using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.MealDTO.GetRandomMeal
{
    public record GetRandomMealResponse(bool Flag, string message = null!, Meal meal = null!);
}
