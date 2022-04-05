using Microsoft.EntityFrameworkCore.Migrations;

namespace AndreAirLinesAPI.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_BasePrice_SalePercentageId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_SalePercentageId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "SalePercentageId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "SalePercentage",
                table: "BasePrice");

            migrationBuilder.AddColumn<double>(
                name: "SalePercentage",
                table: "Ticket",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalePercentage",
                table: "Ticket");

            migrationBuilder.AddColumn<int>(
                name: "SalePercentageId",
                table: "Ticket",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SalePercentage",
                table: "BasePrice",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_SalePercentageId",
                table: "Ticket",
                column: "SalePercentageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_BasePrice_SalePercentageId",
                table: "Ticket",
                column: "SalePercentageId",
                principalTable: "BasePrice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
