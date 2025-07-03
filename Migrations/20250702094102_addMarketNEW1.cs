using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketApi.Migrations
{
    /// <inheritdoc />
    public partial class addMarketNEW1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Markets_ProductId",
                table: "Markets",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Markets_Products_ProductId",
                table: "Markets",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Markets_Products_ProductId",
                table: "Markets");

            migrationBuilder.DropIndex(
                name: "IX_Markets_ProductId",
                table: "Markets");
        }
    }
}
