using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    public class MealNutrientsUseCase
    {
        public List<double?> MealNutrientsUseCaseMethod(List<Food> foods, List<int> weights)
        {
            double? calories = 0;
            double? protein = 0.0;
            double? carbohydrates = 0.0;
            double? fats = 0.0;

            for (int i = 0;i<foods.Count;i++)
            {
                calories += foods[i].Calories100g * weights[i] / 100;
                protein += foods[i].Protein100g * weights[i] / 100;
                carbohydrates += foods[i].Carbohdryates100g * weights[i] / 100;
                fats += foods[i].Fats100g * weights[i] / 100;
            }

            return new List<double?> { calories , protein, carbohydrates, fats };
        }
    }
}
