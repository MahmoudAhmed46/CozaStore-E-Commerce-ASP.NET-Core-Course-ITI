using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceWebSite.Context.Migrations
{
    /// <inheritdoc />
    public partial class initassd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_categoryId",
                table: "Categories");

            migrationBuilder.AlterColumn<int>(
                name: "categoryId",
                table: "Categories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_categoryId",
                table: "Categories",
                column: "categoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_categoryId",
                table: "Categories");

            migrationBuilder.AlterColumn<int>(
                name: "categoryId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_categoryId",
                table: "Categories",
                column: "categoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
