using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.MealDTO.AddLikeToMeal
{
    public class AddLikeToMealDTO
    {
        [Required]
        public string NameOfMeal { get; set; } = string.Empty;
    }
}
