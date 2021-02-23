using Microsoft.EntityFrameworkCore.Migrations;

namespace FriendsTraveling.DataLayer.Migrations
{
    public partial class AddForeignKeyToJourneyRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JourneyRequests_AspNetUsers_AppUserId",
                table: "JourneyRequests");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "JourneyRequests",
                newName: "OrganizerId");

            migrationBuilder.RenameIndex(
                name: "IX_JourneyRequests_AppUserId",
                table: "JourneyRequests",
                newName: "IX_JourneyRequests_OrganizerId");

            migrationBuilder.AddColumn<int>(
                name: "JourneyRequestStatus",
                table: "JourneyRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JourneyRequests_RequestUserId",
                table: "JourneyRequests",
                column: "RequestUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_JourneyRequests_AspNetUsers_OrganizerId",
                table: "JourneyRequests",
                column: "OrganizerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JourneyRequests_AspNetUsers_RequestUserId",
                table: "JourneyRequests",
                column: "RequestUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JourneyRequests_AspNetUsers_OrganizerId",
                table: "JourneyRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_JourneyRequests_AspNetUsers_RequestUserId",
                table: "JourneyRequests");

            migrationBuilder.DropIndex(
                name: "IX_JourneyRequests_RequestUserId",
                table: "JourneyRequests");

            migrationBuilder.DropColumn(
                name: "JourneyRequestStatus",
                table: "JourneyRequests");

            migrationBuilder.RenameColumn(
                name: "OrganizerId",
                table: "JourneyRequests",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_JourneyRequests_OrganizerId",
                table: "JourneyRequests",
                newName: "IX_JourneyRequests_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_JourneyRequests_AspNetUsers_AppUserId",
                table: "JourneyRequests",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
