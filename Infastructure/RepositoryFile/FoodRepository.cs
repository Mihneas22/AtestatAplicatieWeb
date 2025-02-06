using Application.DTOs.FoodDTO.AddFood;
using Application.DTOs.FoodDTO.GetFoodByName;
using Application.Repository;
using Infastructure.Context;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infastructure.RepositoryFile
{
    public class FoodRepository : IFood
    {
        public ApplicationDbContext _dbContext;

        public FoodRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AddFoodResponse> AddFoodAsync(AddFoodDTO addFoodDTO)
        {
            if (addFoodDTO == null)
                return new AddFoodResponse(false, "Date invalide...");

            var foodName = await _dbContext.FoodsEntity.FirstOrDefaultAsync(u => u.Name == addFoodDTO.Name);

            if(foodName != null)
                return new AddFoodResponse(false, "Mancare care exista deja...");

            _dbContext.FoodsEntity.Add(new Food
            {
                Name = addFoodDTO.Name,
                HealthRank = addFoodDTO.HealthRank,
                Description = addFoodDTO.Description,
                Calories100g = addFoodDTO.Calories100g,
                Protein100g = addFoodDTO.Protein100g,
                Carbohdryates100g = addFoodDTO.Carbohdryates100g,
                Fats100g = addFoodDTO.Fats100g,
            });
            await _dbContext.SaveChangesAsync();

            var foodExist = await _dbContext.FoodsEntity.FirstOrDefaultAsync(u => u.Name == addFoodDTO.Name);
            if( foodExist != null )
                return new AddFoodResponse(true, "Succes!");
            else
                return new AddFoodResponse(false, "Nu a fost adaugat cu succes...");
        }

        public async Task<GetFoodByNameResponse> GetFoodByNameAsync(GetFoodByNameDTO getFoodByNameDTO)
        {
            if(getFoodByNameDTO == null )
                return new GetFoodByNameResponse(false, "Date invalide...");

            var food = await _dbContext.FoodsEntity.FirstOrDefaultAsync(u => u.Name == getFoodByNameDTO.Name);
            if(food == null)
                return new GetFoodByNameResponse(false, "Mancarea nu a fost gasita");
            else
                return new GetFoodByNameResponse(true, "Succes", food);
        }
    }
}
