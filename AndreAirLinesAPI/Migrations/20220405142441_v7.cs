using Microsoft.EntityFrameworkCore.Migrations;

namespace AndreAirLinesAPI.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasePrice_Airport_DestinationAcronym",
                table: "BasePrice");

            migrationBuilder.DropForeignKey(
                name: "FK_BasePrice_Airport_OriginAcronym",
                table: "BasePrice");

            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Airport_DestinationAcronym",
                table: "Flight");

            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Airport_OriginAcronym",
                table: "Flight");

            migrationBuilder.RenameColumn(
                name: "OriginAcronym",
                table: "Flight",
                newName: "OriginIATA_Code");

            migrationBuilder.RenameColumn(
                name: "DestinationAcronym",
                table: "Flight",
                newName: "DestinationIATA_Code");

            migrationBuilder.RenameIndex(
                name: "IX_Flight_OriginAcronym",
                table: "Flight",
                newName: "IX_Flight_OriginIATA_Code");

            migrationBuilder.RenameIndex(
                name: "IX_Flight_DestinationAcronym",
                table: "Flight",
                newName: "IX_Flight_DestinationIATA_Code");

            migrationBuilder.RenameColumn(
                name: "OriginAcronym",
                table: "BasePrice",
                newName: "OriginIATA_Code");

            migrationBuilder.RenameColumn(
                name: "DestinationAcronym",
                table: "BasePrice",
                newName: "DestinationIATA_Code");

            migrationBuilder.RenameIndex(
                name: "IX_BasePrice_OriginAcronym",
                table: "BasePrice",
                newName: "IX_BasePrice_OriginIATA_Code");

            migrationBuilder.RenameIndex(
                name: "IX_BasePrice_DestinationAcronym",
                table: "BasePrice",
                newName: "IX_BasePrice_DestinationIATA_Code");

            migrationBuilder.RenameColumn(
                name: "Acronym",
                table: "Airport",
                newName: "IATA_Code");

            migrationBuilder.AddForeignKey(
                name: "FK_BasePrice_Airport_DestinationIATA_Code",
                table: "BasePrice",
                column: "DestinationIATA_Code",
                principalTable: "Airport",
                principalColumn: "IATA_Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BasePrice_Airport_OriginIATA_Code",
                table: "BasePrice",
                column: "OriginIATA_Code",
                principalTable: "Airport",
                principalColumn: "IATA_Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Airport_DestinationIATA_Code",
                table: "Flight",
                column: "DestinationIATA_Code",
                principalTable: "Airport",
                principalColumn: "IATA_Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Airport_OriginIATA_Code",
                table: "Flight",
                column: "OriginIATA_Code",
                principalTable: "Airport",
                principalColumn: "IATA_Code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasePrice_Airport_DestinationIATA_Code",
                table: "BasePrice");

            migrationBuilder.DropForeignKey(
                name: "FK_BasePrice_Airport_OriginIATA_Code",
                table: "BasePrice");

            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Airport_DestinationIATA_Code",
                table: "Flight");

            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Airport_OriginIATA_Code",
                table: "Flight");

            migrationBuilder.RenameColumn(
                name: "OriginIATA_Code",
                table: "Flight",
                newName: "OriginAcronym");

            migrationBuilder.RenameColumn(
                name: "DestinationIATA_Code",
                table: "Flight",
                newName: "DestinationAcronym");

            migrationBuilder.RenameIndex(
                name: "IX_Flight_OriginIATA_Code",
                table: "Flight",
                newName: "IX_Flight_OriginAcronym");

            migrationBuilder.RenameIndex(
                name: "IX_Flight_DestinationIATA_Code",
                table: "Flight",
                newName: "IX_Flight_DestinationAcronym");

            migrationBuilder.RenameColumn(
                name: "OriginIATA_Code",
                table: "BasePrice",
                newName: "OriginAcronym");

            migrationBuilder.RenameColumn(
                name: "DestinationIATA_Code",
                table: "BasePrice",
                newName: "DestinationAcronym");

            migrationBuilder.RenameIndex(
                name: "IX_BasePrice_OriginIATA_Code",
                table: "BasePrice",
                newName: "IX_BasePrice_OriginAcronym");

            migrationBuilder.RenameIndex(
                name: "IX_BasePrice_DestinationIATA_Code",
                table: "BasePrice",
                newName: "IX_BasePrice_DestinationAcronym");

            migrationBuilder.RenameColumn(
                name: "IATA_Code",
                table: "Airport",
                newName: "Acronym");

            migrationBuilder.AddForeignKey(
                name: "FK_BasePrice_Airport_DestinationAcronym",
                table: "BasePrice",
                column: "DestinationAcronym",
                principalTable: "Airport",
                principalColumn: "Acronym",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BasePrice_Airport_OriginAcronym",
                table: "BasePrice",
                column: "OriginAcronym",
                principalTable: "Airport",
                principalColumn: "Acronym",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Airport_DestinationAcronym",
                table: "Flight",
                column: "DestinationAcronym",
                principalTable: "Airport",
                principalColumn: "Acronym",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Airport_OriginAcronym",
                table: "Flight",
                column: "OriginAcronym",
                principalTable: "Airport",
                principalColumn: "Acronym",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
