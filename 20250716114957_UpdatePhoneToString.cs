using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsDashBoard.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePhoneToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product Detailes_products_ProductId",
                table: "Product Detailes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product Detailes",
                table: "Product Detailes");

            migrationBuilder.RenameTable(
                name: "Product Detailes",
                newName: "productDetailes");

            migrationBuilder.RenameIndex(
                name: "IX_Product Detailes_ProductId",
                table: "productDetailes",
                newName: "IX_productDetailes_ProductId");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productDetailes",
                table: "productDetailes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_productDetailes_products_ProductId",
                table: "productDetailes",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productDetailes_products_ProductId",
                table: "productDetailes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productDetailes",
                table: "productDetailes");

            migrationBuilder.RenameTable(
                name: "productDetailes",
                newName: "Product Detailes");

            migrationBuilder.RenameIndex(
                name: "IX_productDetailes_ProductId",
                table: "Product Detailes",
                newName: "IX_Product Detailes_ProductId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Phone",
                table: "employees",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product Detailes",
                table: "Product Detailes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product Detailes_products_ProductId",
                table: "Product Detailes",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
