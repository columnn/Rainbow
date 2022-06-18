using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rainbow.Data.Migrations
{
    public partial class UsernameColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colors_AspNetUsers_UserId",
                table: "Colors");

            migrationBuilder.DropIndex(
                name: "IX_Colors_UserId",
                table: "Colors");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Colors",
                newName: "Username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Colors",
                newName: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Colors_UserId",
                table: "Colors",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colors_AspNetUsers_UserId",
                table: "Colors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
