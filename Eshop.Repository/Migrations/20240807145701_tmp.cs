using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EshopWebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class tmp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Products",
                newName: "Images");

            migrationBuilder.AddColumn<Guid>(
                name: "AgencyId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageTextBox",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Agencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_AgencyId",
                table: "Products",
                column: "AgencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Agencies_AgencyId",
                table: "Products",
                column: "AgencyId",
                principalTable: "Agencies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Agencies_AgencyId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Agencies");

            migrationBuilder.DropIndex(
                name: "IX_Products_AgencyId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AgencyId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageTextBox",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Images",
                table: "Products",
                newName: "ImageUrl");
        }
    }
}
