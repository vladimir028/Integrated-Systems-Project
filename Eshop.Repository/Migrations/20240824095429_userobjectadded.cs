using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EshopWebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class userobjectadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EshopApplicationUserId1",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EshopApplicationUserId1",
                table: "Orders",
                column: "EshopApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_EshopApplicationUserId1",
                table: "Orders",
                column: "EshopApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_EshopApplicationUserId1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_EshopApplicationUserId1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "EshopApplicationUserId1",
                table: "Orders");
        }
    }
}
