using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales.API.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAttributesOnTableProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Product",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "ComissionPrice",
                table: "Product",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "Product",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ComissionPrice",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Product");
        }
    }
}
