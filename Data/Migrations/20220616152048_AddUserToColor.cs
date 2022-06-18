using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rainbow.Data.Migrations
{
    public partial class AddUserToColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Colors",
                newName: "ColorId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Colors",
                type: "TEXT",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colors_AspNetUsers_UserId",
                table: "Colors");

            migrationBuilder.DropIndex(
                name: "IX_Colors_UserId",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Colors");

            migrationBuilder.RenameColumn(
                name: "ColorId",
                table: "Colors",
                newName: "Id");
        }
    }
}
