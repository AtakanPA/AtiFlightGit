using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtiFlight.Migrations
{
    /// <inheritdoc />
    public partial class kontroldeg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "FlyRoutes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isAvailable",
                table: "AirPlanes",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "FlyRoutes");

            migrationBuilder.DropColumn(
                name: "isAvailable",
                table: "AirPlanes");
        }
    }
}
