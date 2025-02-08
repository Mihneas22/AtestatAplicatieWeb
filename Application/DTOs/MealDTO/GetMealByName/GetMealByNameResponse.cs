using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.MealDTO.GetMealByName
{
    public record GetMealByNameResponse(bool Flag, string message = null!, Meal meal = null!);
}
