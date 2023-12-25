using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtiFlight.Migrations
{
    /// <inheritdoc />
    public partial class corrections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_AirPlanes_AirPlaneID",
                table: "Flights");

            migrationBuilder.AlterColumn<int>(
                name: "AirPlaneID",
                table: "Flights",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_AirPlanes_AirPlaneID",
                table: "Flights",
                column: "AirPlaneID",
                principalTable: "AirPlanes",
                principalColumn: "AirPlaneID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_AirPlanes_AirPlaneID",
                table: "Flights");

            migrationBuilder.AlterColumn<int>(
                name: "AirPlaneID",
                table: "Flights",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_AirPlanes_AirPlaneID",
                table: "Flights",
                column: "AirPlaneID",
                principalTable: "AirPlanes",
                principalColumn: "AirPlaneID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
