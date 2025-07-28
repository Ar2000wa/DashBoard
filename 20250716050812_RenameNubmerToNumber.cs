using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsDashBoard.Migrations
{
    /// <inheritdoc />
    public partial class RenameNubmerToNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productsDetailes_products_ProductId",
                table: "productsDetailes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productsDetailes",
                table: "productsDetailes");

            migrationBuilder.RenameTable(
                name: "productsDetailes",
                newName: "productDetailes");

            migrationBuilder.RenameIndex(
                name: "IX_productsDetailes_ProductId",
                table: "productDetailes",
                newName: "IX_productDetailes_ProductId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Qty",
                table: "productDetailes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "productDetailes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "productDetailes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "productDetailes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_productDetailes",
                table: "productDetailes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.Id);
                });

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

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productDetailes",
                table: "productDetailes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "productDetailes");

            migrationBuilder.RenameTable(
                name: "productDetailes",
                newName: "productsDetailes");

            migrationBuilder.RenameIndex(
                name: "IX_productDetailes_ProductId",
                table: "productsDetailes",
                newName: "IX_productsDetailes_ProductId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Qty",
                table: "productsDetailes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "productsDetailes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "productsDetailes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_productsDetailes",
                table: "productsDetailes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_productsDetailes_products_ProductId",
                table: "productsDetailes",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
