using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsDashBoard.Migrations
{
    /// <inheritdoc />
    public partial class AForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_productsDetailes_ProductId",
                table: "productsDetailes",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_productsDetailes_products_ProductId",
                table: "productsDetailes",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productsDetailes_products_ProductId",
                table: "productsDetailes");

            migrationBuilder.DropIndex(
                name: "IX_productsDetailes_ProductId",
                table: "productsDetailes");
        }
    }
}
