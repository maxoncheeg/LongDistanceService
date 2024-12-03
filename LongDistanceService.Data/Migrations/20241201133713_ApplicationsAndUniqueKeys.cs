using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LongDistanceService.Data.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationsAndUniqueKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_legals_сities_city_id",
                table: "legals");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_сities_receive_city_id",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_сities_send_city_id",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_vehicle_models_brand_id",
                table: "vehicle_models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_сities",
                table: "сities");

            migrationBuilder.RenameTable(
                name: "сities",
                newName: "cities");

            migrationBuilder.AlterColumn<string>(
                name: "function",
                table: "menu_tabs",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_vehicle_models_brand_id_name",
                table: "vehicle_models",
                columns: new[] { "brand_id", "name" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_vehicle_brands_name",
                table: "vehicle_brands",
                column: "name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_units_name",
                table: "units",
                column: "name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_streets_name",
                table: "streets",
                column: "name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_menu_tabs_function",
                table: "menu_tabs",
                column: "function");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_menu_tabs_name",
                table: "menu_tabs",
                column: "name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_legals_phone",
                table: "legals",
                column: "phone");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_individuals_phone",
                table: "individuals",
                column: "phone");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_driver_categories_name",
                table: "driver_categories",
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

            migrationBuilder.AddUniqueConstraint(
                name: "AK_cities_name",
                table: "cities",
                column: "name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cities",
                table: "cities",
                column: "id");

            migrationBuilder.CreateTable(
                name: "applications",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    creator_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applications", x => x.id);
                    table.ForeignKey(
                        name: "FK_applications_users_creator_id",
                        column: x => x.creator_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "application_messages",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    application_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    answered_at = table.Column<int>(type: "integer", nullable: true),
                    text = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_application_messages", x => x.id);
                    table.ForeignKey(
                        name: "FK_application_messages_applications_application_id",
                        column: x => x.application_id,
                        principalTable: "applications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_application_messages_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_application_messages_application_id",
                table: "application_messages",
                column: "application_id");

            migrationBuilder.CreateIndex(
                name: "IX_application_messages_user_id",
                table: "application_messages",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_applications_creator_id",
                table: "applications",
                column: "creator_id");

            migrationBuilder.AddForeignKey(
                name: "FK_legals_cities_city_id",
                table: "legals",
                column: "city_id",
                principalTable: "cities",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_legals_cities_city_id",
                table: "legals");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_cities_receive_city_id",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_cities_send_city_id",
                table: "orders");

            migrationBuilder.DropTable(
                name: "application_messages");

            migrationBuilder.DropTable(
                name: "applications");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_vehicle_models_brand_id_name",
                table: "vehicle_models");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_vehicle_brands_name",
                table: "vehicle_brands");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_units_name",
                table: "units");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_streets_name",
                table: "streets");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_menu_tabs_function",
                table: "menu_tabs");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_menu_tabs_name",
                table: "menu_tabs");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_legals_phone",
                table: "legals");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_individuals_phone",
                table: "individuals");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_driver_categories_name",
                table: "driver_categories");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_cargoes_name",
                table: "cargoes");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_cargo_categories_name",
                table: "cargo_categories");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_banks_name",
                table: "banks");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_cities_name",
                table: "cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cities",
                table: "cities");

            migrationBuilder.RenameTable(
                name: "cities",
                newName: "сities");

            migrationBuilder.AlterColumn<string>(
                name: "function",
                table: "menu_tabs",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_сities",
                table: "сities",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_models_brand_id",
                table: "vehicle_models",
                column: "brand_id");

            migrationBuilder.AddForeignKey(
                name: "FK_legals_сities_city_id",
                table: "legals",
                column: "city_id",
                principalTable: "сities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_сities_receive_city_id",
                table: "orders",
                column: "receive_city_id",
                principalTable: "сities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_сities_send_city_id",
                table: "orders",
                column: "send_city_id",
                principalTable: "сities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
