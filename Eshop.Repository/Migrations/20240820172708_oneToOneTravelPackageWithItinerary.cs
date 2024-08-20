using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EshopWebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class oneToOneTravelPackageWithItinerary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Itineraries_TravelPackageId",
                table: "Itineraries");

            migrationBuilder.CreateIndex(
                name: "IX_Itineraries_TravelPackageId",
                table: "Itineraries",
                column: "TravelPackageId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Itineraries_TravelPackageId",
                table: "Itineraries");

            migrationBuilder.CreateIndex(
                name: "IX_Itineraries_TravelPackageId",
                table: "Itineraries",
                column: "TravelPackageId");
        }
    }
}
