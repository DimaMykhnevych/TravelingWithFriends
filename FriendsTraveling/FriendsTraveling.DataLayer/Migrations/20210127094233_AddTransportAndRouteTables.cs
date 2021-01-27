using Microsoft.EntityFrameworkCore.Migrations;

namespace FriendsTraveling.DataLayer.Migrations
{
    public partial class AddTransportAndRouteTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserJourney_AspNetUsers_AppUserId",
                table: "UserJourney");

            migrationBuilder.DropForeignKey(
                name: "FK_UserJourney_Journey_JourneyId",
                table: "UserJourney");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserJourney",
                table: "UserJourney");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Journey",
                table: "Journey");

            migrationBuilder.RenameTable(
                name: "UserJourney",
                newName: "UserJourneys");

            migrationBuilder.RenameTable(
                name: "Journey",
                newName: "Journeys");

            migrationBuilder.RenameIndex(
                name: "IX_UserJourney_JourneyId",
                table: "UserJourneys",
                newName: "IX_UserJourneys_JourneyId");

            migrationBuilder.RenameIndex(
                name: "IX_UserJourney_AppUserId",
                table: "UserJourneys",
                newName: "IX_UserJourneys_AppUserId");

            migrationBuilder.AddColumn<int>(
                name: "RouteId",
                table: "Journeys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserJourneys",
                table: "UserJourneys",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Journeys",
                table: "Journeys",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Transports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routes_Transports_TransportId",
                        column: x => x.TransportId,
                        principalTable: "Transports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Journeys_RouteId",
                table: "Journeys",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_TransportId",
                table: "Routes",
                column: "TransportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Journeys_Routes_RouteId",
                table: "Journeys",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserJourneys_AspNetUsers_AppUserId",
                table: "UserJourneys",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserJourneys_Journeys_JourneyId",
                table: "UserJourneys",
                column: "JourneyId",
                principalTable: "Journeys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Journeys_Routes_RouteId",
                table: "Journeys");

            migrationBuilder.DropForeignKey(
                name: "FK_UserJourneys_AspNetUsers_AppUserId",
                table: "UserJourneys");

            migrationBuilder.DropForeignKey(
                name: "FK_UserJourneys_Journeys_JourneyId",
                table: "UserJourneys");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Transports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserJourneys",
                table: "UserJourneys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Journeys",
                table: "Journeys");

            migrationBuilder.DropIndex(
                name: "IX_Journeys_RouteId",
                table: "Journeys");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Journeys");

            migrationBuilder.RenameTable(
                name: "UserJourneys",
                newName: "UserJourney");

            migrationBuilder.RenameTable(
                name: "Journeys",
                newName: "Journey");

            migrationBuilder.RenameIndex(
                name: "IX_UserJourneys_JourneyId",
                table: "UserJourney",
                newName: "IX_UserJourney_JourneyId");

            migrationBuilder.RenameIndex(
                name: "IX_UserJourneys_AppUserId",
                table: "UserJourney",
                newName: "IX_UserJourney_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserJourney",
                table: "UserJourney",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Journey",
                table: "Journey",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserJourney_AspNetUsers_AppUserId",
                table: "UserJourney",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserJourney_Journey_JourneyId",
                table: "UserJourney",
                column: "JourneyId",
                principalTable: "Journey",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
