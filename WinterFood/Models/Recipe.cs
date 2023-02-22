namespace WinterFood.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public string Instructions { get; set; }
        public string ImageUrl { get; set; }
        public string Servings { get; set; }
        public string PrepTime { get; set; }
        public string CookTime { get; set; }
    }

    public class Ingredient
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
        public string Units { get; set; }
    }
}
