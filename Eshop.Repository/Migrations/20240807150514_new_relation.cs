using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EshopWebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class new_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Agencies_AgencyId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInOrders_Products_ProductId",
                table: "ProductsInOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInShoppingCarts_Products_ProductId",
                table: "ProductsInShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "TravelPackages");

            migrationBuilder.RenameIndex(
                name: "IX_Products_AgencyId",
                table: "TravelPackages",
                newName: "IX_TravelPackages_AgencyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TravelPackages",
                table: "TravelPackages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInOrders_TravelPackages_ProductId",
                table: "ProductsInOrders",
                column: "ProductId",
                principalTable: "TravelPackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInShoppingCarts_TravelPackages_ProductId",
                table: "ProductsInShoppingCarts",
                column: "ProductId",
                principalTable: "TravelPackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelPackages_Agencies_AgencyId",
                table: "TravelPackages",
                column: "AgencyId",
                principalTable: "Agencies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInOrders_TravelPackages_ProductId",
                table: "ProductsInOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInShoppingCarts_TravelPackages_ProductId",
                table: "ProductsInShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelPackages_Agencies_AgencyId",
                table: "TravelPackages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TravelPackages",
                table: "TravelPackages");

            migrationBuilder.RenameTable(
                name: "TravelPackages",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_TravelPackages_AgencyId",
                table: "Products",
                newName: "IX_Products_AgencyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Agencies_AgencyId",
                table: "Products",
                column: "AgencyId",
                principalTable: "Agencies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInOrders_Products_ProductId",
                table: "ProductsInOrders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInShoppingCarts_Products_ProductId",
                table: "ProductsInShoppingCarts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
