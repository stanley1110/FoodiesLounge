using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodiesLoungeDataAccess.Migrations
{
    public partial class Inital32 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCarts_AspNetUsers_IdentityUserId",
                table: "shoppingCarts");

            migrationBuilder.RenameColumn(
                name: "IdentityUserId",
                table: "shoppingCarts",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_shoppingCarts_IdentityUserId",
                table: "shoppingCarts",
                newName: "IX_shoppingCarts_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCarts_AspNetUsers_ApplicationUserId",
                table: "shoppingCarts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCarts_AspNetUsers_ApplicationUserId",
                table: "shoppingCarts");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "shoppingCarts",
                newName: "IdentityUserId");

            migrationBuilder.RenameIndex(
                name: "IX_shoppingCarts_ApplicationUserId",
                table: "shoppingCarts",
                newName: "IX_shoppingCarts_IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCarts_AspNetUsers_IdentityUserId",
                table: "shoppingCarts",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
