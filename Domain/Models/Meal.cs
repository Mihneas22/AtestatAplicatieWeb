using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Meal
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Type { get; set; } //Cina, Pranz, Mic-Dejun

        public string? Description { get; set; }

        public int? Likes { get; set; }

        public List<string>? PersonsLiked {  get; set; }

        public List<string>? FoodNames { get; set; }

        public List<int>? FoodWeights { get; set; }
    }
}
