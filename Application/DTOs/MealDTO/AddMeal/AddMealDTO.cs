using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.DTOs.MealDTO.AddMeal
{
    public class AddMealDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Type { get; set; } = string.Empty; //Cina, Pranz, Mic-Dejun

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public List<string> FoodNames { get; set; } = new List<string>();
    }
}
