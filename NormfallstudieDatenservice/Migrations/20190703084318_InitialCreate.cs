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
                name: "EasyjetFlights",
                columns: table => new
                {
                    EasyjetFlightId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartDestinationDestinationId = table.Column<int>(nullable: true),
                    EndDestinationDestinationId = table.Column<int>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    EmptyPlaces = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyjetFlights", x => x.EasyjetFlightId);
                    table.ForeignKey(
                        name: "FK_EasyjetFlights_Destinations_EndDestinationDestinationId",
                        column: x => x.EndDestinationDestinationId,
                        principalTable: "Destinations",
                        principalColumn: "DestinationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EasyjetFlights_Destinations_StartDestinationDestinationId",
                        column: x => x.StartDestinationDestinationId,
                        principalTable: "Destinations",
                        principalColumn: "DestinationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EasyjetFlights_EndDestinationDestinationId",
                table: "EasyjetFlights",
                column: "EndDestinationDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_EasyjetFlights_StartDestinationDestinationId",
                table: "EasyjetFlights",
                column: "StartDestinationDestinationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EasyjetFlights");

            migrationBuilder.DropTable(
                name: "Destinations");
        }
    }
}
