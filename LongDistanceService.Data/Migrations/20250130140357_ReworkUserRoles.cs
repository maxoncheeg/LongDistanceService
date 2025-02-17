using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LongDistanceService.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReworkUserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "menu_tab_rights");

            migrationBuilder.DropTable(
                name: "menu_tabs");

            migrationBuilder.DropIndex(
                name: "IX_roles_name",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "name",
                table: "users");

            migrationBuilder.DropColumn(
                name: "surname",
                table: "users");

            migrationBuilder.DropColumn(
                name: "name",
                table: "roles");

            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "roles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_roles_type",
                table: "roles",
                column: "type",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_roles_type",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "type",
                table: "roles");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "users",
                type: "character varying(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "surname",
                table: "users",
                type: "character varying(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "roles",
                type: "character varying(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "menu_tabs",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dll = table.Column<string>(type: "text", nullable: true),
                    function = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    order = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    parent_id = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menu_tabs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "menu_tab_rights",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    tab_id = table.Column<int>(type: "integer", nullable: false),
                    d = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    e = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    r = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    w = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menu_tab_rights", x => new { x.role_id, x.tab_id });
                    table.ForeignKey(
                        name: "FK_menu_tab_rights_menu_tabs_tab_id",
                        column: x => x.tab_id,
                        principalTable: "menu_tabs",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_menu_tab_rights_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_roles_name",
                table: "roles",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_menu_tab_rights_tab_id",
                table: "menu_tab_rights",
                column: "tab_id");

            migrationBuilder.CreateIndex(
                name: "IX_menu_tabs_name",
                table: "menu_tabs",
                column: "name",
                unique: true);
        }
    }
}
