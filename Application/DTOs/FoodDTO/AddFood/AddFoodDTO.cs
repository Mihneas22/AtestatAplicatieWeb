using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.FoodDTO.AddFood
{
    public class AddFoodDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public char HealthRank { get; set; } = char.MinValue;

        [Required]
        public double? Calories100g { get; set; } = double.MinValue;

        [Required]
        public double? Protein100g { get; set; } = double.MinValue;

        [Required]
        public double? Carbohdryates100g { get; set; } = double.MinValue;

        [Required]
        public double? Fats100g { get; set; } = double.MinValue;
    }
}
