using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public char? HealthRank { get; set; } //A,B,C,D

        public double? Calories100g { get; set; }

        public double? Protein100g { get; set; }

        public double? Carbohdryates100g { get; set; }

        public double? Fats100g { get; set; }
    }
}
