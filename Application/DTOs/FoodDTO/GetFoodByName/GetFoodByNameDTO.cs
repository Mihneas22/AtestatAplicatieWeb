﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.FoodDTO.GetFoodByName
{
    public class GetFoodByNameDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
