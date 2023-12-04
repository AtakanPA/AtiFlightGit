using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtiFlight.Migrations
{
    /// <inheritdoc />
    public partial class duzenlemeler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AirPlaneName",
                table: "AirPlanes",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AirPlaneName",
                table: "AirPlanes");
        }
    }
}
