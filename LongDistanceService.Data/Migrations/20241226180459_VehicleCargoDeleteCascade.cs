using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LongDistanceService.Data.Migrations
{
    /// <inheritdoc />
    public partial class VehicleCargoDeleteCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_cargo_categories_vehicles_vehicle_id",
                table: "vehicle_cargo_categories");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_cargo_categories_vehicles_vehicle_id",
                table: "vehicle_cargo_categories",
                column: "vehicle_id",
                principalTable: "vehicles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_cargo_categories_vehicles_vehicle_id",
                table: "vehicle_cargo_categories");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_cargo_categories_vehicles_vehicle_id",
                table: "vehicle_cargo_categories",
                column: "vehicle_id",
                principalTable: "vehicles",
                principalColumn: "id");
        }
    }
}
