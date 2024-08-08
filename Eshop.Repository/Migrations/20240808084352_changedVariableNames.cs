using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EshopWebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class changedVariableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInOrders_TravelPackages_ProductId",
                table: "ProductsInOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInShoppingCarts_TravelPackages_ProductId",
                table: "ProductsInShoppingCarts");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "ProductsInShoppingCarts",
                newName: "NumberOfTravelers");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductsInShoppingCarts",
                newName: "TravelPackageId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsInShoppingCarts_ProductId",
                table: "ProductsInShoppingCarts",
                newName: "IX_ProductsInShoppingCarts_TravelPackageId");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "ProductsInOrders",
                newName: "NumberOfTravelers");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductsInOrders",
                newName: "TravelPackageId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsInOrders_ProductId",
                table: "ProductsInOrders",
                newName: "IX_ProductsInOrders_TravelPackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInOrders_TravelPackages_TravelPackageId",
                table: "ProductsInOrders",
                column: "TravelPackageId",
                principalTable: "TravelPackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInShoppingCarts_TravelPackages_TravelPackageId",
                table: "ProductsInShoppingCarts",
                column: "TravelPackageId",
                principalTable: "TravelPackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInOrders_TravelPackages_TravelPackageId",
                table: "ProductsInOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInShoppingCarts_TravelPackages_TravelPackageId",
                table: "ProductsInShoppingCarts");

            migrationBuilder.RenameColumn(
                name: "TravelPackageId",
                table: "ProductsInShoppingCarts",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "NumberOfTravelers",
                table: "ProductsInShoppingCarts",
                newName: "Quantity");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsInShoppingCarts_TravelPackageId",
                table: "ProductsInShoppingCarts",
                newName: "IX_ProductsInShoppingCarts_ProductId");

            migrationBuilder.RenameColumn(
                name: "TravelPackageId",
                table: "ProductsInOrders",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "NumberOfTravelers",
                table: "ProductsInOrders",
                newName: "Quantity");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsInOrders_TravelPackageId",
                table: "ProductsInOrders",
                newName: "IX_ProductsInOrders_ProductId");

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
        }
    }
}
