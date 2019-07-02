using Microsoft.EntityFrameworkCore.Migrations;

namespace NormfallstudieDatenservice.Migrations.Easyjet
{
    public partial class createEJ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EasyjetDestinations",
                columns: table => new
                {
                    EasyjetDestinationId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyjetDestinations", x => x.EasyjetDestinationId);
                });

            migrationBuilder.CreateTable(
                name: "EasyjetFlights",
                columns: table => new
                {
                    EasyjetFlightId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartDestinationEasyjetDestinationId = table.Column<int>(nullable: true),
                    EndDestinationEasyjetDestinationId = table.Column<int>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    EmptyPlaces = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyjetFlights", x => x.EasyjetFlightId);
                    table.ForeignKey(
                        name: "FK_EasyjetFlights_EasyjetDestinations_EndDestinationEasyjetDestinationId",
                        column: x => x.EndDestinationEasyjetDestinationId,
                        principalTable: "EasyjetDestinations",
                        principalColumn: "EasyjetDestinationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EasyjetFlights_EasyjetDestinations_StartDestinationEasyjetDestinationId",
                        column: x => x.StartDestinationEasyjetDestinationId,
                        principalTable: "EasyjetDestinations",
                        principalColumn: "EasyjetDestinationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EasyjetFlights_EndDestinationEasyjetDestinationId",
                table: "EasyjetFlights",
                column: "EndDestinationEasyjetDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_EasyjetFlights_StartDestinationEasyjetDestinationId",
                table: "EasyjetFlights",
                column: "StartDestinationEasyjetDestinationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EasyjetFlights");

            migrationBuilder.DropTable(
                name: "EasyjetDestinations");
        }
    }
}
