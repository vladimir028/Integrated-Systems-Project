using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EshopWebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class changedTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInOrders_Orders_OrderId",
                table: "ProductsInOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInOrders_TravelPackages_TravelPackageId",
                table: "ProductsInOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInShoppingCarts_ShoppingCarts_ShoppingCartId",
                table: "ProductsInShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInShoppingCarts_TravelPackages_TravelPackageId",
                table: "ProductsInShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsInShoppingCarts",
                table: "ProductsInShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsInOrders",
                table: "ProductsInOrders");

            migrationBuilder.RenameTable(
                name: "ProductsInShoppingCarts",
                newName: "TravelPackageInShoppingCarts");

            migrationBuilder.RenameTable(
                name: "ProductsInOrders",
                newName: "TravelPackageInOrders");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsInShoppingCarts_TravelPackageId",
                table: "TravelPackageInShoppingCarts",
                newName: "IX_TravelPackageInShoppingCarts_TravelPackageId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsInShoppingCarts_ShoppingCartId",
                table: "TravelPackageInShoppingCarts",
                newName: "IX_TravelPackageInShoppingCarts_ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsInOrders_TravelPackageId",
                table: "TravelPackageInOrders",
                newName: "IX_TravelPackageInOrders_TravelPackageId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsInOrders_OrderId",
                table: "TravelPackageInOrders",
                newName: "IX_TravelPackageInOrders_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TravelPackageInShoppingCarts",
                table: "TravelPackageInShoppingCarts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TravelPackageInOrders",
                table: "TravelPackageInOrders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelPackageInOrders_Orders_OrderId",
                table: "TravelPackageInOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelPackageInOrders_TravelPackages_TravelPackageId",
                table: "TravelPackageInOrders",
                column: "TravelPackageId",
                principalTable: "TravelPackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelPackageInShoppingCarts_ShoppingCarts_ShoppingCartId",
                table: "TravelPackageInShoppingCarts",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelPackageInShoppingCarts_TravelPackages_TravelPackageId",
                table: "TravelPackageInShoppingCarts",
                column: "TravelPackageId",
                principalTable: "TravelPackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelPackageInOrders_Orders_OrderId",
                table: "TravelPackageInOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelPackageInOrders_TravelPackages_TravelPackageId",
                table: "TravelPackageInOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelPackageInShoppingCarts_ShoppingCarts_ShoppingCartId",
                table: "TravelPackageInShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelPackageInShoppingCarts_TravelPackages_TravelPackageId",
                table: "TravelPackageInShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TravelPackageInShoppingCarts",
                table: "TravelPackageInShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TravelPackageInOrders",
                table: "TravelPackageInOrders");

            migrationBuilder.RenameTable(
                name: "TravelPackageInShoppingCarts",
                newName: "ProductsInShoppingCarts");

            migrationBuilder.RenameTable(
                name: "TravelPackageInOrders",
                newName: "ProductsInOrders");

            migrationBuilder.RenameIndex(
                name: "IX_TravelPackageInShoppingCarts_TravelPackageId",
                table: "ProductsInShoppingCarts",
                newName: "IX_ProductsInShoppingCarts_TravelPackageId");

            migrationBuilder.RenameIndex(
                name: "IX_TravelPackageInShoppingCarts_ShoppingCartId",
                table: "ProductsInShoppingCarts",
                newName: "IX_ProductsInShoppingCarts_ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_TravelPackageInOrders_TravelPackageId",
                table: "ProductsInOrders",
                newName: "IX_ProductsInOrders_TravelPackageId");

            migrationBuilder.RenameIndex(
                name: "IX_TravelPackageInOrders_OrderId",
                table: "ProductsInOrders",
                newName: "IX_ProductsInOrders_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsInShoppingCarts",
                table: "ProductsInShoppingCarts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsInOrders",
                table: "ProductsInOrders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInOrders_Orders_OrderId",
                table: "ProductsInOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInOrders_TravelPackages_TravelPackageId",
                table: "ProductsInOrders",
                column: "TravelPackageId",
                principalTable: "TravelPackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInShoppingCarts_ShoppingCarts_ShoppingCartId",
                table: "ProductsInShoppingCarts",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
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
    }
}
