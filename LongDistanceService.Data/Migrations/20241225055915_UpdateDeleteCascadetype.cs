using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LongDistanceService.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDeleteCascadetype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_application_messages_applications_application_id",
                table: "application_messages");

            migrationBuilder.DropForeignKey(
                name: "FK_application_messages_users_user_id",
                table: "application_messages");

            migrationBuilder.DropForeignKey(
                name: "FK_applications_users_creator_id",
                table: "applications");

            migrationBuilder.DropForeignKey(
                name: "FK_cargo_categories_units_unit_id",
                table: "cargo_categories");

            migrationBuilder.DropForeignKey(
                name: "FK_cargoes_cargo_categories_category_id",
                table: "cargoes");

            migrationBuilder.DropForeignKey(
                name: "FK_drivers_driver_categories_category_id",
                table: "drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_legals_banks_bank_id",
                table: "legals");

            migrationBuilder.DropForeignKey(
                name: "FK_legals_cities_city_id",
                table: "legals");

            migrationBuilder.DropForeignKey(
                name: "FK_legals_streets_street_id",
                table: "legals");

            migrationBuilder.DropForeignKey(
                name: "FK_menu_tab_rights_menu_tabs_tab_id",
                table: "menu_tab_rights");

            migrationBuilder.DropForeignKey(
                name: "FK_menu_tab_rights_roles_role_id",
                table: "menu_tab_rights");

            migrationBuilder.DropForeignKey(
                name: "FK_order_cargoes_cargoes_cargo_id",
                table: "order_cargoes");

            migrationBuilder.DropForeignKey(
                name: "FK_order_cargoes_orders_order_id",
                table: "order_cargoes");

            migrationBuilder.DropForeignKey(
                name: "FK_order_drivers_drivers_driver_id",
                table: "order_drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_order_drivers_orders_order_id",
                table: "order_drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_cities_receive_city_id",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_cities_send_city_id",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_streets_receive_street_id",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_streets_send_street_id",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_vehicles_vehicle_id",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_users_roles_role_id",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_cargo_categories_cargo_categories_cargo_category_id",
                table: "vehicle_cargo_categories");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_cargo_categories_vehicles_vehicle_id",
                table: "vehicle_cargo_categories");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_models_vehicle_brands_brand_id",
                table: "vehicle_models");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicles_vehicle_models_model_id",
                table: "vehicles");

            migrationBuilder.AddForeignKey(
                name: "FK_application_messages_applications_application_id",
                table: "application_messages",
                column: "application_id",
                principalTable: "applications",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_application_messages_users_user_id",
                table: "application_messages",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_applications_users_creator_id",
                table: "applications",
                column: "creator_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_cargo_categories_units_unit_id",
                table: "cargo_categories",
                column: "unit_id",
                principalTable: "units",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_cargoes_cargo_categories_category_id",
                table: "cargoes",
                column: "category_id",
                principalTable: "cargo_categories",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_drivers_driver_categories_category_id",
                table: "drivers",
                column: "category_id",
                principalTable: "driver_categories",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_legals_banks_bank_id",
                table: "legals",
                column: "bank_id",
                principalTable: "banks",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_legals_cities_city_id",
                table: "legals",
                column: "city_id",
                principalTable: "cities",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_legals_streets_street_id",
                table: "legals",
                column: "street_id",
                principalTable: "streets",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_menu_tab_rights_menu_tabs_tab_id",
                table: "menu_tab_rights",
                column: "tab_id",
                principalTable: "menu_tabs",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_menu_tab_rights_roles_role_id",
                table: "menu_tab_rights",
                column: "role_id",
                principalTable: "roles",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_cargoes_cargoes_cargo_id",
                table: "order_cargoes",
                column: "cargo_id",
                principalTable: "cargoes",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_cargoes_orders_order_id",
                table: "order_cargoes",
                column: "order_id",
                principalTable: "orders",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_drivers_drivers_driver_id",
                table: "order_drivers",
                column: "driver_id",
                principalTable: "drivers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_drivers_orders_order_id",
                table: "order_drivers",
                column: "order_id",
                principalTable: "orders",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_cities_receive_city_id",
                table: "orders",
                column: "receive_city_id",
                principalTable: "cities",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_cities_send_city_id",
                table: "orders",
                column: "send_city_id",
                principalTable: "cities",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_streets_receive_street_id",
                table: "orders",
                column: "receive_street_id",
                principalTable: "streets",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_streets_send_street_id",
                table: "orders",
                column: "send_street_id",
                principalTable: "streets",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_vehicles_vehicle_id",
                table: "orders",
                column: "vehicle_id",
                principalTable: "vehicles",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_roles_role_id",
                table: "users",
                column: "role_id",
                principalTable: "roles",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_cargo_categories_cargo_categories_cargo_category_id",
                table: "vehicle_cargo_categories",
                column: "cargo_category_id",
                principalTable: "cargo_categories",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_cargo_categories_vehicles_vehicle_id",
                table: "vehicle_cargo_categories",
                column: "vehicle_id",
                principalTable: "vehicles",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_models_vehicle_brands_brand_id",
                table: "vehicle_models",
                column: "brand_id",
                principalTable: "vehicle_brands",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicles_vehicle_models_model_id",
                table: "vehicles",
                column: "model_id",
                principalTable: "vehicle_models",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_application_messages_applications_application_id",
                table: "application_messages");

            migrationBuilder.DropForeignKey(
                name: "FK_application_messages_users_user_id",
                table: "application_messages");

            migrationBuilder.DropForeignKey(
                name: "FK_applications_users_creator_id",
                table: "applications");

            migrationBuilder.DropForeignKey(
                name: "FK_cargo_categories_units_unit_id",
                table: "cargo_categories");

            migrationBuilder.DropForeignKey(
                name: "FK_cargoes_cargo_categories_category_id",
                table: "cargoes");

            migrationBuilder.DropForeignKey(
                name: "FK_drivers_driver_categories_category_id",
                table: "drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_legals_banks_bank_id",
                table: "legals");

            migrationBuilder.DropForeignKey(
                name: "FK_legals_cities_city_id",
                table: "legals");

            migrationBuilder.DropForeignKey(
                name: "FK_legals_streets_street_id",
                table: "legals");

            migrationBuilder.DropForeignKey(
                name: "FK_menu_tab_rights_menu_tabs_tab_id",
                table: "menu_tab_rights");

            migrationBuilder.DropForeignKey(
                name: "FK_menu_tab_rights_roles_role_id",
                table: "menu_tab_rights");

            migrationBuilder.DropForeignKey(
                name: "FK_order_cargoes_cargoes_cargo_id",
                table: "order_cargoes");

            migrationBuilder.DropForeignKey(
                name: "FK_order_cargoes_orders_order_id",
                table: "order_cargoes");

            migrationBuilder.DropForeignKey(
                name: "FK_order_drivers_drivers_driver_id",
                table: "order_drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_order_drivers_orders_order_id",
                table: "order_drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_cities_receive_city_id",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_cities_send_city_id",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_streets_receive_street_id",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_streets_send_street_id",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_vehicles_vehicle_id",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_users_roles_role_id",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_cargo_categories_cargo_categories_cargo_category_id",
                table: "vehicle_cargo_categories");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_cargo_categories_vehicles_vehicle_id",
                table: "vehicle_cargo_categories");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_models_vehicle_brands_brand_id",
                table: "vehicle_models");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicles_vehicle_models_model_id",
                table: "vehicles");

            migrationBuilder.AddForeignKey(
                name: "FK_application_messages_applications_application_id",
                table: "application_messages",
                column: "application_id",
                principalTable: "applications",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_application_messages_users_user_id",
                table: "application_messages",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_applications_users_creator_id",
                table: "applications",
                column: "creator_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cargo_categories_units_unit_id",
                table: "cargo_categories",
                column: "unit_id",
                principalTable: "units",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cargoes_cargo_categories_category_id",
                table: "cargoes",
                column: "category_id",
                principalTable: "cargo_categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_drivers_driver_categories_category_id",
                table: "drivers",
                column: "category_id",
                principalTable: "driver_categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_legals_banks_bank_id",
                table: "legals",
                column: "bank_id",
                principalTable: "banks",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_legals_cities_city_id",
                table: "legals",
                column: "city_id",
                principalTable: "cities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_legals_streets_street_id",
                table: "legals",
                column: "street_id",
                principalTable: "streets",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_menu_tab_rights_menu_tabs_tab_id",
                table: "menu_tab_rights",
                column: "tab_id",
                principalTable: "menu_tabs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_menu_tab_rights_roles_role_id",
                table: "menu_tab_rights",
                column: "role_id",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_cargoes_cargoes_cargo_id",
                table: "order_cargoes",
                column: "cargo_id",
                principalTable: "cargoes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_cargoes_orders_order_id",
                table: "order_cargoes",
                column: "order_id",
                principalTable: "orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_drivers_drivers_driver_id",
                table: "order_drivers",
                column: "driver_id",
                principalTable: "drivers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_drivers_orders_order_id",
                table: "order_drivers",
                column: "order_id",
                principalTable: "orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_cities_receive_city_id",
                table: "orders",
                column: "receive_city_id",
                principalTable: "cities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_cities_send_city_id",
                table: "orders",
                column: "send_city_id",
                principalTable: "cities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_streets_receive_street_id",
                table: "orders",
                column: "receive_street_id",
                principalTable: "streets",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_streets_send_street_id",
                table: "orders",
                column: "send_street_id",
                principalTable: "streets",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_vehicles_vehicle_id",
                table: "orders",
                column: "vehicle_id",
                principalTable: "vehicles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_roles_role_id",
                table: "users",
                column: "role_id",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_cargo_categories_cargo_categories_cargo_category_id",
                table: "vehicle_cargo_categories",
                column: "cargo_category_id",
                principalTable: "cargo_categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_cargo_categories_vehicles_vehicle_id",
                table: "vehicle_cargo_categories",
                column: "vehicle_id",
                principalTable: "vehicles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_models_vehicle_brands_brand_id",
                table: "vehicle_models",
                column: "brand_id",
                principalTable: "vehicle_brands",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_vehicles_vehicle_models_model_id",
                table: "vehicles",
                column: "model_id",
                principalTable: "vehicle_models",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
