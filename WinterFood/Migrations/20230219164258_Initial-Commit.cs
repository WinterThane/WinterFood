using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WinterFood.Migrations
{
    /// <inheritdoc />
    public partial class InitialCommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Instructions = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Servings = table.Column<int>(type: "INTEGER", nullable: false),
                    PrepTime = table.Column<string>(type: "TEXT", nullable: false),
                    CookTime = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RecipeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<string>(type: "TEXT", nullable: false),
                    Units = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredient_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CookTime", "Description", "ImageUrl", "Instructions", "Name", "PrepTime", "Servings" },
                values: new object[] { 1, "30 minutes", "Classic spaghetti bolognese made with ground beef, tomatoes, and pasta.", "https://www.example.com/spaghetti-bolognese.jpg", "Brown the ground beef and onions in a large pot. Add the garlic and cook for a minute. Add the beans, tomato sauce, tomato paste, chili powder, cumin, oregano, salt, pepper, and water. Simmer for 30 minutes, stirring occasionally.", "Spaghetti Bolognese", "10 minutes", 4 });

            migrationBuilder.InsertData(
                table: "Ingredient",
                columns: new[] { "Id", "Amount", "Name", "RecipeId", "Units" },
                values: new object[,]
                {
                    { 1, "1 pound", "Spaghetti", 1, "box" },
                    { 2, "1 pound", "Ground Beef", 1, "package" },
                    { 3, "24 ounces", "Tomato Sauce", 1, "can" },
                    { 4, "1", "Onion", 1, "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_RecipeId",
                table: "Ingredient",
                column: "RecipeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
