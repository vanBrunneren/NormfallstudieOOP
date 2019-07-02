using Microsoft.EntityFrameworkCore.Migrations;

namespace NormfallstudieDatenservice.Migrations
{
    public partial class rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Destinations");

            migrationBuilder.CreateTable(
                name: "SwissDestinations",
                columns: table => new
                {
                    SwissDestinationId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwissDestinations", x => x.SwissDestinationId);
                });

            migrationBuilder.CreateTable(
                name: "SwissFlights",
                columns: table => new
                {
                    SwissFlightId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartDestinationSwissDestinationId = table.Column<int>(nullable: true),
                    EndDestinationSwissDestinationId = table.Column<int>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    EmptyPlaces = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwissFlights", x => x.SwissFlightId);
                    table.ForeignKey(
                        name: "FK_SwissFlights_SwissDestinations_EndDestinationSwissDestinationId",
                        column: x => x.EndDestinationSwissDestinationId,
                        principalTable: "SwissDestinations",
                        principalColumn: "SwissDestinationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SwissFlights_SwissDestinations_StartDestinationSwissDestinationId",
                        column: x => x.StartDestinationSwissDestinationId,
                        principalTable: "SwissDestinations",
                        principalColumn: "SwissDestinationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SwissFlights_EndDestinationSwissDestinationId",
                table: "SwissFlights",
                column: "EndDestinationSwissDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_SwissFlights_StartDestinationSwissDestinationId",
                table: "SwissFlights",
                column: "StartDestinationSwissDestinationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SwissFlights");

            migrationBuilder.DropTable(
                name: "SwissDestinations");

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
                    Date = table.Column<string>(nullable: true),
                    EmptyPlaces = table.Column<int>(nullable: false),
                    EndDestinationDestinationId = table.Column<int>(nullable: true),
                    StartDestinationDestinationId = table.Column<int>(nullable: true)
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
    }
}
