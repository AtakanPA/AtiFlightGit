using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AtiFlight.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "End",
                table: "FlyRoutes");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "FlyRoutes");

            migrationBuilder.AddColumn<int>(
                name: "EndID",
                table: "FlyRoutes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartID",
                table: "FlyRoutes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Iller",
                columns: table => new
                {
                    IlId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iller", x => x.IlId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlyRoutes_EndID",
                table: "FlyRoutes",
                column: "EndID");

            migrationBuilder.CreateIndex(
                name: "IX_FlyRoutes_StartID",
                table: "FlyRoutes",
                column: "StartID");

            migrationBuilder.AddForeignKey(
                name: "FK_FlyRoutes_Iller_EndID",
                table: "FlyRoutes",
                column: "EndID",
                principalTable: "Iller",
                principalColumn: "IlId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlyRoutes_Iller_StartID",
                table: "FlyRoutes",
                column: "StartID",
                principalTable: "Iller",
                principalColumn: "IlId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlyRoutes_Iller_EndID",
                table: "FlyRoutes");

            migrationBuilder.DropForeignKey(
                name: "FK_FlyRoutes_Iller_StartID",
                table: "FlyRoutes");

            migrationBuilder.DropTable(
                name: "Iller");

            migrationBuilder.DropIndex(
                name: "IX_FlyRoutes_EndID",
                table: "FlyRoutes");

            migrationBuilder.DropIndex(
                name: "IX_FlyRoutes_StartID",
                table: "FlyRoutes");

            migrationBuilder.DropColumn(
                name: "EndID",
                table: "FlyRoutes");

            migrationBuilder.DropColumn(
                name: "StartID",
                table: "FlyRoutes");

            migrationBuilder.AddColumn<string>(
                name: "End",
                table: "FlyRoutes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Start",
                table: "FlyRoutes",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
