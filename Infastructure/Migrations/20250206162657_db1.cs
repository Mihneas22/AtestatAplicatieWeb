using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class db1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MealsEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Likes = table.Column<int>(type: "int", nullable: true),
                    FoodNames = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealsEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodsEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HealthRank = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Calories100g = table.Column<double>(type: "float", nullable: true),
                    Protein100g = table.Column<double>(type: "float", nullable: true),
                    Carbohdryates100g = table.Column<double>(type: "float", nullable: true),
                    Fats100g = table.Column<double>(type: "float", nullable: true),
                    MealId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodsEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodsEntity_MealsEntity_MealId",
                        column: x => x.MealId,
                        principalTable: "MealsEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodsEntity_MealId",
                table: "FoodsEntity",
                column: "MealId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodsEntity");

            migrationBuilder.DropTable(
                name: "MealsEntity");
        }
    }
}
