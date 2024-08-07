using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EshopWebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class modifiedRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelPackages_Agencies_AgencyId",
                table: "TravelPackages");

            migrationBuilder.AlterColumn<Guid>(
                name: "AgencyId",
                table: "TravelPackages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelPackages_Agencies_AgencyId",
                table: "TravelPackages",
                column: "AgencyId",
                principalTable: "Agencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelPackages_Agencies_AgencyId",
                table: "TravelPackages");

            migrationBuilder.AlterColumn<Guid>(
                name: "AgencyId",
                table: "TravelPackages",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelPackages_Agencies_AgencyId",
                table: "TravelPackages",
                column: "AgencyId",
                principalTable: "Agencies",
                principalColumn: "Id");
        }
    }
}
