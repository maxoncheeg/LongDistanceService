using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LongDistanceService.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixUniqueKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_vehicle_models_brand_id_name",
                table: "vehicle_models");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_vehicle_brands_name",
                table: "vehicle_brands");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_users_login",
                table: "users");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_units_name",
                table: "units");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_streets_name",
                table: "streets");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_menu_tabs_name",
                table: "menu_tabs");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_legals_bank_id_bank_account",
                table: "legals");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_legals_phone",
                table: "legals");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_legals_tin",
                table: "legals");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_individuals_passport_series",
                table: "individuals");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_individuals_phone",
                table: "individuals");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_drivers_employee_number",
                table: "drivers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_driver_categories_name",
                table: "driver_categories");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_cities_name",
                table: "cities");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_cargoes_name",
                table: "cargoes");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_cargo_categories_name",
                table: "cargo_categories");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_banks_name",
                table: "banks");

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_license_plate",
                table: "vehicles",
                column: "license_plate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_models_brand_id_name",
                table: "vehicle_models",
                columns: new[] { "brand_id", "name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_brands_name",
                table: "vehicle_brands",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_login",
                table: "users",
                column: "login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_units_name",
                table: "units",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_streets_name",
                table: "streets",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_menu_tabs_name",
                table: "menu_tabs",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_legals_bank_id_bank_account",
                table: "legals",
                columns: new[] { "bank_id", "bank_account" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_legals_phone",
                table: "legals",
                column: "phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_legals_tin",
                table: "legals",
                column: "tin",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_individuals_passport_series",
                table: "individuals",
                column: "passport_series",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_individuals_phone",
                table: "individuals",
                column: "phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_drivers_employee_number",
                table: "drivers",
                column: "employee_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_driver_categories_name",
                table: "driver_categories",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cities_name",
                table: "cities",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cargoes_name",
                table: "cargoes",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cargo_categories_name",
                table: "cargo_categories",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_banks_name",
                table: "banks",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_vehicles_license_plate",
                table: "vehicles");

            migrationBuilder.DropIndex(
                name: "IX_vehicle_models_brand_id_name",
                table: "vehicle_models");

            migrationBuilder.DropIndex(
                name: "IX_vehicle_brands_name",
                table: "vehicle_brands");

            migrationBuilder.DropIndex(
                name: "IX_users_login",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_units_name",
                table: "units");

            migrationBuilder.DropIndex(
                name: "IX_streets_name",
                table: "streets");

            migrationBuilder.DropIndex(
                name: "IX_menu_tabs_name",
                table: "menu_tabs");

            migrationBuilder.DropIndex(
                name: "IX_legals_bank_id_bank_account",
                table: "legals");

            migrationBuilder.DropIndex(
                name: "IX_legals_phone",
                table: "legals");

            migrationBuilder.DropIndex(
                name: "IX_legals_tin",
                table: "legals");

            migrationBuilder.DropIndex(
                name: "IX_individuals_passport_series",
                table: "individuals");

            migrationBuilder.DropIndex(
                name: "IX_individuals_phone",
                table: "individuals");

            migrationBuilder.DropIndex(
                name: "IX_drivers_employee_number",
                table: "drivers");

            migrationBuilder.DropIndex(
                name: "IX_driver_categories_name",
                table: "driver_categories");

            migrationBuilder.DropIndex(
                name: "IX_cities_name",
                table: "cities");

            migrationBuilder.DropIndex(
                name: "IX_cargoes_name",
                table: "cargoes");

            migrationBuilder.DropIndex(
                name: "IX_cargo_categories_name",
                table: "cargo_categories");

            migrationBuilder.DropIndex(
                name: "IX_banks_name",
                table: "banks");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_vehicle_models_brand_id_name",
                table: "vehicle_models",
                columns: new[] { "brand_id", "name" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_vehicle_brands_name",
                table: "vehicle_brands",
                column: "name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_users_login",
                table: "users",
                column: "login");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_units_name",
                table: "units",
                column: "name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_streets_name",
                table: "streets",
                column: "name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_menu_tabs_name",
                table: "menu_tabs",
                column: "name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_legals_bank_id_bank_account",
                table: "legals",
                columns: new[] { "bank_id", "bank_account" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_legals_phone",
                table: "legals",
                column: "phone");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_legals_tin",
                table: "legals",
                column: "tin");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_individuals_passport_series",
                table: "individuals",
                column: "passport_series");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_individuals_phone",
                table: "individuals",
                column: "phone");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_drivers_employee_number",
                table: "drivers",
                column: "employee_number");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_driver_categories_name",
                table: "driver_categories",
                column: "name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_cities_name",
                table: "cities",
                column: "name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_cargoes_name",
                table: "cargoes",
                column: "name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_cargo_categories_name",
                table: "cargo_categories",
                column: "name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_banks_name",
                table: "banks",
                column: "name");
        }
    }
}
