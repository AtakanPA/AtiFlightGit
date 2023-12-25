using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AtiFlight.Migrations
{
    /// <inheritdoc />
    public partial class correction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_AspNetUsers_UserId",
                table: "Ticket");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Ticket",
                newName: "YolcuId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_UserId",
                table: "Ticket",
                newName: "IX_Ticket_YolcuId");

            migrationBuilder.CreateTable(
                name: "Yolcular",
                columns: table => new
                {
                    YolcuId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TelNo = table.Column<string>(type: "text", nullable: false),
                    AdSoyad = table.Column<string>(type: "text", nullable: false),
                    cinsiyet = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yolcular", x => x.YolcuId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Yolcular_YolcuId",
                table: "Ticket",
                column: "YolcuId",
                principalTable: "Yolcular",
                principalColumn: "YolcuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Yolcular_YolcuId",
                table: "Ticket");

            migrationBuilder.DropTable(
                name: "Yolcular");

            migrationBuilder.RenameColumn(
                name: "YolcuId",
                table: "Ticket",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_YolcuId",
                table: "Ticket",
                newName: "IX_Ticket_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_AspNetUsers_UserId",
                table: "Ticket",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
