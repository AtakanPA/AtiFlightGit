using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtiFlight.Migrations
{
    /// <inheritdoc />
    public partial class migiller : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlyRoutes_Iller_EndID",
                table: "FlyRoutes");

            migrationBuilder.DropForeignKey(
                name: "FK_FlyRoutes_Iller_StartID",
                table: "FlyRoutes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Iller",
                table: "Iller");

            migrationBuilder.RenameTable(
                name: "Iller",
                newName: "Illers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Illers",
                table: "Illers",
                column: "IlId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlyRoutes_Illers_EndID",
                table: "FlyRoutes");

            migrationBuilder.DropForeignKey(
                name: "FK_FlyRoutes_Illers_StartID",
                table: "FlyRoutes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Illers",
                table: "Illers");

            migrationBuilder.RenameTable(
                name: "Illers",
                newName: "Iller");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Iller",
                table: "Iller",
                column: "IlId");

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
    }
}
