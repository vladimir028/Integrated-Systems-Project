using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EshopWebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class newRelationAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Itineraries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TravelPackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itineraries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Itineraries_TravelPackages_TravelPackageId",
                        column: x => x.TravelPackageId,
                        principalTable: "TravelPackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlannedRoutes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RouteDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfActivities = table.Column<int>(type: "int", nullable: false),
                    Activity = table.Column<int>(type: "int", nullable: false),
                    StartFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ItineraryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedRoutes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlannedRoutes_Itineraries_ItineraryId",
                        column: x => x.ItineraryId,
                        principalTable: "Itineraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Itineraries_TravelPackageId",
                table: "Itineraries",
                column: "TravelPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedRoutes_ItineraryId",
                table: "PlannedRoutes",
                column: "ItineraryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlannedRoutes");

            migrationBuilder.DropTable(
                name: "Itineraries");
        }
    }
}
