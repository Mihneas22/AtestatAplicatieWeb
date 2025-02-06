using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.FoodDTO.GetFoodByName
{
    public record GetFoodByNameResponse(bool Flag, string message = null!, Food Food = null!);
}
