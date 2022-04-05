using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AndreAirLinesAPI.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Passenger_PassengerCpf",
                table: "Flight");

            migrationBuilder.DropIndex(
                name: "IX_Flight_PassengerCpf",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "PassengerCpf",
                table: "Flight");

            migrationBuilder.CreateTable(
                name: "BasePrice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginAcronym = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DestinationAcronym = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Value = table.Column<double>(type: "float", nullable: false),
                    SalePercentage = table.Column<double>(type: "float", nullable: false),
                    InclusionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasePrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasePrice_Airport_DestinationAcronym",
                        column: x => x.DestinationAcronym,
                        principalTable: "Airport",
                        principalColumn: "Acronym",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BasePrice_Airport_OriginAcronym",
                        column: x => x.OriginAcronym,
                        principalTable: "Airport",
                        principalColumn: "Acronym",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class_Value = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightId = table.Column<int>(type: "int", nullable: true),
                    PassengerCpf = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ClassId = table.Column<int>(type: "int", nullable: true),
                    BasePriceId = table.Column<int>(type: "int", nullable: true),
                    SalePercentageId = table.Column<int>(type: "int", nullable: true),
                    TotalValue = table.Column<double>(type: "float", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_BasePrice_BasePriceId",
                        column: x => x.BasePriceId,
                        principalTable: "BasePrice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_BasePrice_SalePercentageId",
                        column: x => x.SalePercentageId,
                        principalTable: "BasePrice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_Flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_Passenger_PassengerCpf",
                        column: x => x.PassengerCpf,
                        principalTable: "Passenger",
                        principalColumn: "Cpf",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasePrice_DestinationAcronym",
                table: "BasePrice",
                column: "DestinationAcronym");

            migrationBuilder.CreateIndex(
                name: "IX_BasePrice_OriginAcronym",
                table: "BasePrice",
                column: "OriginAcronym");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_BasePriceId",
                table: "Ticket",
                column: "BasePriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ClassId",
                table: "Ticket",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_FlightId",
                table: "Ticket",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_PassengerCpf",
                table: "Ticket",
                column: "PassengerCpf");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_SalePercentageId",
                table: "Ticket",
                column: "SalePercentageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "BasePrice");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.AddColumn<string>(
                name: "PassengerCpf",
                table: "Flight",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flight_PassengerCpf",
                table: "Flight",
                column: "PassengerCpf");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Passenger_PassengerCpf",
                table: "Flight",
                column: "PassengerCpf",
                principalTable: "Passenger",
                principalColumn: "Cpf",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
