using Application.DTOs.MealDTO.AddMeal;
using Application.DTOs.MealDTO.GetRandomMeal;
using Application.Repository;
using Infastructure.Context;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.FoodDTO.AddFood;
using Application.DTOs.MealDTO.GetMealByName;

namespace Infastructure.RepositoryFile
{
    public class MealRepository : IMeal
    {
        public ApplicationDbContext _dbContext;

        public MealRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AddMealResponse> AddMealAsync(AddMealDTO addMealDTO)
        {
            if (addMealDTO == null)
                return new AddMealResponse(false, "Date invalide...");

            var mealName = await _dbContext.MealsEntity.FirstOrDefaultAsync(u => u.Name == addMealDTO.Name);

            if(mealName != null)
                return new AddMealResponse(false, "Meniul deja exista");

            List<Food> foodList = new List<Food>();

            foreach (var foodName in addMealDTO.FoodNames)
            {
                var food = await _dbContext.FoodsEntity.FirstOrDefaultAsync(u => u.Name == foodName);
                if(food == null)
                    return new AddMealResponse(false, $"Nu exista mancarea, {foodName}. Considera sa o adaugi!");
                foodList.Add(food);
            }

            _dbContext.MealsEntity.Add(new Meal
            {
                Name = addMealDTO.Name,
                Type = addMealDTO.Type,
                Description = addMealDTO.Description,
                FoodNames = addMealDTO.FoodNames,
                Likes = 0,
                Foods = foodList
            });

            await _dbContext.SaveChangesAsync();

            return new AddMealResponse(true, "Succes!");
        }

        public async Task<GetMealByNameResponse> GetMealByNameAsync(GetMealByNameDTO getMealByNameDTO)
        {
            if (getMealByNameDTO == null)
                return new GetMealByNameResponse(false, "Date invalide...");

            var meal = await _dbContext.MealsEntity.FirstOrDefaultAsync(u => u.Name == getMealByNameDTO.Name);

            if(meal == null)
                return new GetMealByNameResponse(false, "Nu exista...");
            else
                return new GetMealByNameResponse(true, "Succes!", meal);
        }

        public async Task<GetRandomMealResponse> GetRandomMealAsync()
        {
            var mealList = await _dbContext.MealsEntity.ToListAsync();

            Random rnd = new Random();
            int r = rnd.Next(mealList.Count);

            return new GetRandomMealResponse(true, "Succes!", mealList[r]);
        }
    }
}
