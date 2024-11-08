using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LongDistanceService.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "сities",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_сities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "banks",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_banks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "driver_categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_driver_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "individuals",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    phone = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: false),
                    passport_series = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    passport_date = table.Column<DateOnly>(type: "date", maxLength: 10, nullable: false),
                    passport_issued = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    surname = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    patronymic = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_individuals", x => x.id);
                    table.UniqueConstraint("AK_individuals_passport_series", x => x.passport_series);
                });

            migrationBuilder.CreateTable(
                name: "streets",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_streets", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "units",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_units", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vehicle_brands",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle_brands", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "drivers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    employee_number = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    @class = table.Column<string>(name: "class", type: "text", nullable: false, defaultValue: "0"),
                    birth_year = table.Column<int>(type: "integer", nullable: false, defaultValue: 2004),
                    experience = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    surname = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    patronymic = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drivers", x => x.id);
                    table.UniqueConstraint("AK_drivers_employee_number", x => x.employee_number);
                    table.CheckConstraint("CK_experience", "experience > 0 OR experience = 0");
                    table.ForeignKey(
                        name: "FK_drivers_driver_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "driver_categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legals",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    city_id = table.Column<int>(type: "integer", nullable: false),
                    street_id = table.Column<int>(type: "integer", nullable: false),
                    bank_id = table.Column<int>(type: "integer", nullable: false),
                    company_name = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    phone = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: false),
                    tin = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    bank_account = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    house_number = table.Column<int>(type: "integer", maxLength: 32, nullable: false),
                    OfficeNumber = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    surname = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    patronymic = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_legals", x => x.id);
                    table.UniqueConstraint("AK_legals_bank_id_bank_account", x => new { x.bank_id, x.bank_account });
                    table.UniqueConstraint("AK_legals_tin", x => x.tin);
                    table.ForeignKey(
                        name: "FK_legals_banks_bank_id",
                        column: x => x.bank_id,
                        principalTable: "banks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_legals_streets_street_id",
                        column: x => x.street_id,
                        principalTable: "streets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_legals_сities_city_id",
                        column: x => x.city_id,
                        principalTable: "сities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cargo_categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    unit_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cargo_categories", x => x.id);
                    table.ForeignKey(
                        name: "FK_cargo_categories_units_unit_id",
                        column: x => x.unit_id,
                        principalTable: "units",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicle_models",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    brand_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle_models", x => x.id);
                    table.ForeignKey(
                        name: "FK_vehicle_models_vehicle_brands_brand_id",
                        column: x => x.brand_id,
                        principalTable: "vehicle_brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cargoes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    category_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cargoes", x => x.id);
                    table.ForeignKey(
                        name: "FK_cargoes_cargo_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "cargo_categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    model_id = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false, defaultValue: 1970),
                    overhaul_year = table.Column<int>(type: "integer", nullable: false, defaultValue: 1970),
                    license_plate = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    kilometerage = table.Column<decimal>(type: "numeric(9,2)", precision: 9, scale: 2, nullable: false, defaultValue: 0m),
                    image_path = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicles", x => x.id);
                    table.UniqueConstraint("AK_vehicles_license_plate", x => x.license_plate);
                    table.CheckConstraint("CK_kilometerage", "kilometerage > 0 OR kilometerage = 0");
                    table.ForeignKey(
                        name: "FK_vehicles_vehicle_models_model_id",
                        column: x => x.model_id,
                        principalTable: "vehicle_models",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    vehicle_id = table.Column<int>(type: "integer", nullable: false),
                    ReceiverId = table.Column<int>(type: "integer", nullable: false),
                    sender_type = table.Column<int>(type: "integer", nullable: false),
                    SenderId = table.Column<int>(type: "integer", nullable: false),
                    receiver_type = table.Column<int>(type: "integer", nullable: false),
                    send_city_id = table.Column<int>(type: "integer", nullable: false),
                    send_street_id = table.Column<int>(type: "integer", nullable: false),
                    send_house_number = table.Column<string>(type: "text", nullable: false),
                    receive_city_id = table.Column<int>(type: "integer", nullable: false),
                    receive_street_id = table.Column<int>(type: "integer", nullable: false),
                    receive_house_number = table.Column<string>(type: "text", nullable: false),
                    state = table.Column<int>(type: "integer", nullable: false),
                    route_length = table.Column<decimal>(type: "numeric(9,2)", precision: 9, scale: 2, nullable: false),
                    loading_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                    table.CheckConstraint("CK_RouteLength", "route_length > 0");
                    table.ForeignKey(
                        name: "FK_orders_streets_receive_street_id",
                        column: x => x.receive_street_id,
                        principalTable: "streets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_streets_send_street_id",
                        column: x => x.send_street_id,
                        principalTable: "streets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_vehicles_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_сities_receive_city_id",
                        column: x => x.receive_city_id,
                        principalTable: "сities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_сities_send_city_id",
                        column: x => x.send_city_id,
                        principalTable: "сities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicle_cargo_categories",
                columns: table => new
                {
                    cargo_category_id = table.Column<int>(type: "integer", nullable: false),
                    vehicle_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle_cargo_categories", x => new { x.vehicle_id, x.cargo_category_id });
                    table.ForeignKey(
                        name: "FK_vehicle_cargo_categories_cargo_categories_cargo_category_id",
                        column: x => x.cargo_category_id,
                        principalTable: "cargo_categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vehicle_cargo_categories_vehicles_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_cargoes",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "integer", nullable: false),
                    cargo_id = table.Column<int>(type: "integer", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(9,3)", precision: 9, scale: 3, nullable: false),
                    weight = table.Column<decimal>(type: "numeric(9,3)", precision: 9, scale: 3, nullable: false),
                    price = table.Column<decimal>(type: "numeric(14,2)", precision: 14, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_cargoes", x => new { x.cargo_id, x.order_id });
                    table.CheckConstraint("CK_amount", "amount > 0");
                    table.CheckConstraint("CK_price", "price > 0");
                    table.CheckConstraint("CK_weight", "weight > 0");
                    table.ForeignKey(
                        name: "FK_order_cargoes_cargoes_cargo_id",
                        column: x => x.cargo_id,
                        principalTable: "cargoes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_cargoes_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_drivers",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "integer", nullable: false),
                    driver_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_drivers", x => new { x.driver_id, x.order_id });
                    table.ForeignKey(
                        name: "FK_order_drivers_drivers_driver_id",
                        column: x => x.driver_id,
                        principalTable: "drivers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_drivers_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cargo_categories_unit_id",
                table: "cargo_categories",
                column: "unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_cargoes_category_id",
                table: "cargoes",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_drivers_CategoryId",
                table: "drivers",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_legals_city_id",
                table: "legals",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_legals_street_id",
                table: "legals",
                column: "street_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_cargoes_order_id",
                table: "order_cargoes",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_drivers_order_id",
                table: "order_drivers",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_receive_city_id",
                table: "orders",
                column: "receive_city_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_receive_street_id",
                table: "orders",
                column: "receive_street_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_send_city_id",
                table: "orders",
                column: "send_city_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_send_street_id",
                table: "orders",
                column: "send_street_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_vehicle_id",
                table: "orders",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_cargo_categories_cargo_category_id",
                table: "vehicle_cargo_categories",
                column: "cargo_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_models_brand_id",
                table: "vehicle_models",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_model_id",
                table: "vehicles",
                column: "model_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "individuals");

            migrationBuilder.DropTable(
                name: "legals");

            migrationBuilder.DropTable(
                name: "order_cargoes");

            migrationBuilder.DropTable(
                name: "order_drivers");

            migrationBuilder.DropTable(
                name: "vehicle_cargo_categories");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "banks");

            migrationBuilder.DropTable(
                name: "cargoes");

            migrationBuilder.DropTable(
                name: "drivers");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "cargo_categories");

            migrationBuilder.DropTable(
                name: "driver_categories");

            migrationBuilder.DropTable(
                name: "streets");

            migrationBuilder.DropTable(
                name: "vehicles");

            migrationBuilder.DropTable(
                name: "сities");

            migrationBuilder.DropTable(
                name: "units");

            migrationBuilder.DropTable(
                name: "vehicle_models");

            migrationBuilder.DropTable(
                name: "vehicle_brands");
        }
    }
}
