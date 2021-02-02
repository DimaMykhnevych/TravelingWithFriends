using Microsoft.EntityFrameworkCore.Migrations;

namespace FriendsTraveling.DataLayer.Migrations
{
    public partial class AddRelationshipBetweenImageAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Images_AppUserId",
                table: "Images",
                column: "AppUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_AspNetUsers_AppUserId",
                table: "Images",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_AspNetUsers_AppUserId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_AppUserId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Images");
        }
    }
}
