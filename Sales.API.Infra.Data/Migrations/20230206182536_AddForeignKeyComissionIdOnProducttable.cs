using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales.API.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyComissionIdOnProducttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ComissionId",
                table: "Product",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Product_ComissionId",
                table: "Product",
                column: "ComissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Comission_ComissionId",
                table: "Product",
                column: "ComissionId",
                principalTable: "Comission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Comission_ComissionId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ComissionId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ComissionId",
                table: "Product");
        }
    }
}
