using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtiFlight.Migrations
{
    /// <inheritdoc />
    public partial class migseats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_AspNetUsers_UserId",
                table: "Seats");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Seats",
                newName: "YolcuId");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_UserId",
                table: "Seats",
                newName: "IX_Seats_YolcuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Yolcular_YolcuId",
                table: "Seats",
                column: "YolcuId",
                principalTable: "Yolcular",
                principalColumn: "YolcuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Yolcular_YolcuId",
                table: "Seats");

            migrationBuilder.RenameColumn(
                name: "YolcuId",
                table: "Seats",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_YolcuId",
                table: "Seats",
                newName: "IX_Seats_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_AspNetUsers_UserId",
                table: "Seats",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
