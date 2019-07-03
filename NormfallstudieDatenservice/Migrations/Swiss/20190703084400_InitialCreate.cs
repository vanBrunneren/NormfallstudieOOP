using Microsoft.EntityFrameworkCore.Migrations;

namespace NormfallstudieDatenservice.Migrations.Swiss
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
                name: "SwissFlights",
                columns: table => new
                {
                    SwissFlightId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartDestinationDestinationId = table.Column<int>(nullable: true),
                    EndDestinationDestinationId = table.Column<int>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    EmptyPlaces = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwissFlights", x => x.SwissFlightId);
                    table.ForeignKey(
                        name: "FK_SwissFlights_Destinations_EndDestinationDestinationId",
                        column: x => x.EndDestinationDestinationId,
                        principalTable: "Destinations",
                        principalColumn: "DestinationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SwissFlights_Destinations_StartDestinationDestinationId",
                        column: x => x.StartDestinationDestinationId,
                        principalTable: "Destinations",
                        principalColumn: "DestinationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SwissFlights_EndDestinationDestinationId",
                table: "SwissFlights",
                column: "EndDestinationDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_SwissFlights_StartDestinationDestinationId",
                table: "SwissFlights",
                column: "StartDestinationDestinationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SwissFlights");

            migrationBuilder.DropTable(
                name: "Destinations");
        }
    }
}
