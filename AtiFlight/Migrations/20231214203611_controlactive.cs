using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtiFlight.Migrations
{
    /// <inheritdoc />
    public partial class controlactive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Seats_SeatID",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Ticket");

            migrationBuilder.AlterColumn<int>(
                name: "SeatID",
                table: "Ticket",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Flights",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Seats_SeatID",
                table: "Ticket",
                column: "SeatID",
                principalTable: "Seats",
                principalColumn: "SeatID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Seats_SeatID",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Flights");

            migrationBuilder.AlterColumn<int>(
                name: "SeatID",
                table: "Ticket",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Ticket",
                type: "integer",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Seats_SeatID",
                table: "Ticket",
                column: "SeatID",
                principalTable: "Seats",
                principalColumn: "SeatID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
