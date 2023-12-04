using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtiFlight.Migrations
{
    /// <inheritdoc />
    public partial class seatayar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlyRoutes_Illers_EndID",
                table: "FlyRoutes");

            migrationBuilder.DropForeignKey(
                name: "FK_FlyRoutes_Illers_StartID",
                table: "FlyRoutes");

            migrationBuilder.AddColumn<int>(
                name: "SeatNumber",
                table: "Seats",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "StartID",
                table: "FlyRoutes",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "EndID",
                table: "FlyRoutes",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_FlyRoutes_Illers_EndID",
                table: "FlyRoutes",
                column: "EndID",
                principalTable: "Illers",
                principalColumn: "IlId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlyRoutes_Illers_StartID",
                table: "FlyRoutes",
                column: "StartID",
                principalTable: "Illers",
                principalColumn: "IlId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlyRoutes_Illers_EndID",
                table: "FlyRoutes");

            migrationBuilder.DropForeignKey(
                name: "FK_FlyRoutes_Illers_StartID",
                table: "FlyRoutes");

            migrationBuilder.DropColumn(
                name: "SeatNumber",
                table: "Seats");

            migrationBuilder.AlterColumn<int>(
                name: "StartID",
                table: "FlyRoutes",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EndID",
                table: "FlyRoutes",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FlyRoutes_Illers_EndID",
                table: "FlyRoutes",
                column: "EndID",
                principalTable: "Illers",
                principalColumn: "IlId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlyRoutes_Illers_StartID",
                table: "FlyRoutes",
                column: "StartID",
                principalTable: "Illers",
                principalColumn: "IlId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
