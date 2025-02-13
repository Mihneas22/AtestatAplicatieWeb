using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.MealDTO.SaveMeal
{
    public class SaveMealDTO
    {
        [Required]
        public string mealName { get; set; } = string.Empty;

        [Required]
        public string username { get; set; } = string.Empty;
    }
}
