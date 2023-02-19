using Microsoft.EntityFrameworkCore;
using WinterFood.Models;

namespace WinterFood.Data
{
    public class RecipeService
    {
        private readonly RecipeDbContext dbContext;

        public RecipeService(RecipeDbContext context)
        {
            dbContext = context;
        }

        public async Task<List<Recipe>> GetRecipesAsync()
        {
            return await dbContext.Recipes.ToListAsync();
        }

        public async Task<Recipe> GetRecipeByIdAsync(int id)
        {
            return await dbContext.Recipes.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Recipe> AddRecipeAsync(Recipe recipe)
        {
            try
            {
                dbContext.Recipes.Add(recipe);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return recipe;
        }

        public async Task<Recipe> UpdateRecipeAsync(Recipe recipe)
        {
            try
            {
                var recipeExists = dbContext.Recipes.FirstOrDefault(r => r.Id == recipe.Id);
                if (recipeExists != null)
                {
                    dbContext.Recipes.Update(recipe);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return recipe;
        }

        public async Task DeleteRecipeAsync(Recipe recipe)
        {
            try
            {
                dbContext.Recipes.Remove(recipe);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
