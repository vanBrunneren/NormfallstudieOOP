using Microsoft.EntityFrameworkCore.Migrations;

namespace NormfallstudieDatenservice.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    DestinationId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.DestinationId);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartDestinationDestinationId = table.Column<int>(nullable: true),
                    EndDestinationDestinationId = table.Column<int>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    EmptyPlaces = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_Flights_Destinations_EndDestinationDestinationId",
                        column: x => x.EndDestinationDestinationId,
                        principalTable: "Destinations",
                        principalColumn: "DestinationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flights_Destinations_StartDestinationDestinationId",
                        column: x => x.StartDestinationDestinationId,
                        principalTable: "Destinations",
                        principalColumn: "DestinationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_EndDestinationDestinationId",
                table: "Flights",
                column: "EndDestinationDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_StartDestinationDestinationId",
                table: "Flights",
                column: "StartDestinationDestinationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Destinations");
        }
    }
}
