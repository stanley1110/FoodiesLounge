using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodiesLoungeDataAccess.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_foodTypes",
                table: "foodTypes");

            migrationBuilder.RenameTable(
                name: "foodTypes",
                newName: "FoodTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodTypes",
                table: "FoodTypes",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodTypes",
                table: "FoodTypes");

            migrationBuilder.RenameTable(
                name: "FoodTypes",
                newName: "foodTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_foodTypes",
                table: "foodTypes",
                column: "Id");
        }
    }
}
