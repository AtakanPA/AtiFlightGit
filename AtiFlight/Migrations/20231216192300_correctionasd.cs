using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtiFlight.Migrations
{
    /// <inheritdoc />
    public partial class correctionasd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Flights_FlightID",
                table: "Ticket");

            migrationBuilder.AlterColumn<int>(
                name: "FlightID",
                table: "Ticket",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Flights_FlightID",
                table: "Ticket",
                column: "FlightID",
                principalTable: "Flights",
                principalColumn: "FlightID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Flights_FlightID",
                table: "Ticket");

            migrationBuilder.AlterColumn<int>(
                name: "FlightID",
                table: "Ticket",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Flights_FlightID",
                table: "Ticket",
                column: "FlightID",
                principalTable: "Flights",
                principalColumn: "FlightID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
