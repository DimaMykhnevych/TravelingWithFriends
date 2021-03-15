using Microsoft.EntityFrameworkCore.Migrations;

namespace FriendsTraveling.DataLayer.Migrations
{
    public partial class AddOneToOneRelationBetweenJourneyAndChat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JourneyChatId",
                table: "Chats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Chats_JourneyChatId",
                table: "Chats",
                column: "JourneyChatId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Journeys_JourneyChatId",
                table: "Chats",
                column: "JourneyChatId",
                principalTable: "Journeys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Journeys_JourneyChatId",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_JourneyChatId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "JourneyChatId",
                table: "Chats");
        }
    }
}
