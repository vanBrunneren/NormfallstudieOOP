using Microsoft.EntityFrameworkCore.Migrations;

namespace NormfallstudieDatenservice.Migrations.Ibis
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
                name: "IbisNights",
                columns: table => new
                {
                    IbisNightId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DestinationId = table.Column<int>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    EmptyPlaces = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IbisNights", x => x.IbisNightId);
                    table.ForeignKey(
                        name: "FK_IbisNights_Destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destinations",
                        principalColumn: "DestinationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IbisNights_DestinationId",
                table: "IbisNights",
                column: "DestinationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IbisNights");

            migrationBuilder.DropTable(
                name: "Destinations");
        }
    }
}
