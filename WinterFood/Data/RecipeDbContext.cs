using Microsoft.EntityFrameworkCore;
using WinterFood.Models;

namespace WinterFood.Data
{
    public class RecipeDbContext : DbContext
    {
        public RecipeDbContext(DbContextOptions<RecipeDbContext> options) : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the Recipe and Ingredient entities and their relationships
            modelBuilder.Entity<Recipe>()
                .HasMany(r => r.Ingredients)
                .WithOne()
                .HasForeignKey(i => i.RecipeId);

            // Seed the database with Recipe and Ingredient entities
            modelBuilder.Entity<Recipe>().HasData(
                new Recipe
                {
                    Id = 1,
                    Name = "Spaghetti Bolognese",
                    Description = "Classic spaghetti bolognese made with ground beef, tomatoes, and pasta.",
                    Instructions = "Brown the ground beef and onions in a large pot. " +
                    "Add the garlic and cook for a minute. " +
                    "Add the beans, tomato sauce, tomato paste, chili powder, cumin, oregano, salt, pepper, and water. " +
                    "Simmer for 30 minutes, stirring occasionally.",
                    ImageUrl = "https://www.example.com/spaghetti-bolognese.jpg",
                    Servings = "2",
                    PrepTime = "10 minutes",
                    CookTime = "30 minutes"
                });

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient
                {
                    Id = 1,
                    Name = "Spaghetti",
                    Amount = "1 pound",
                    Units = "box",
                    RecipeId = 1 // Set the foreign key to the Id of the Recipe entity
                },
                new Ingredient
                {
                    Id = 2,
                    Name = "Ground Beef",
                    Amount = "1 pound",
                    Units = "package",
                    RecipeId = 1 // Set the foreign key to the Id of the Recipe entity
                },
                new Ingredient
                {
                    Id = 3,
                    Name = "Tomato Sauce",
                    Amount = "24 ounces",
                    Units = "can",
                    RecipeId = 1 // Set the foreign key to the Id of the Recipe entity
                },
                new Ingredient
                {
                    Id = 4,
                    Name = "Onion",
                    Amount = "1",
                    Units = "",
                    RecipeId = 1 // Set the foreign key to the Id of the Recipe entity
                });


            base.OnModelCreating(modelBuilder);
        }
    }
}
