using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LongDistanceService.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFKs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "function",
                table: "menu_tabs",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_menu_tab_rights_tab_id",
                table: "menu_tab_rights",
                column: "tab_id");

            migrationBuilder.AddForeignKey(
                name: "FK_menu_tab_rights_menu_tabs_tab_id",
                table: "menu_tab_rights",
                column: "tab_id",
                principalTable: "menu_tabs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_menu_tab_rights_users_user_id",
                table: "menu_tab_rights",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_menu_tab_rights_menu_tabs_tab_id",
                table: "menu_tab_rights");

            migrationBuilder.DropForeignKey(
                name: "FK_menu_tab_rights_users_user_id",
                table: "menu_tab_rights");

            migrationBuilder.DropIndex(
                name: "IX_menu_tab_rights_tab_id",
                table: "menu_tab_rights");

            migrationBuilder.AlterColumn<string>(
                name: "function",
                table: "menu_tabs",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
