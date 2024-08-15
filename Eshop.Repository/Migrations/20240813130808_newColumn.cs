using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EshopWebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class newColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AlreadyhasItinerary",
                table: "TravelPackages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlreadyhasItinerary",
                table: "TravelPackages");
        }
    }
}
