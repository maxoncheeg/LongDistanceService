using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LongDistanceService.Data.Migrations
{
    /// <inheritdoc />
    public partial class UniqueUserLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_drivers_driver_categories_CategoryId",
                table: "drivers");

            migrationBuilder.RenameColumn(
                name: "send_house_number",
                table: "orders",
                newName: "send_house");

            migrationBuilder.RenameColumn(
                name: "receive_house_number",
                table: "orders",
                newName: "receive_house");

            migrationBuilder.RenameColumn(
                name: "house_number",
                table: "legals",
                newName: "house");

            migrationBuilder.RenameColumn(
                name: "company_name",
                table: "legals",
                newName: "company");

            migrationBuilder.RenameColumn(
                name: "OfficeNumber",
                table: "legals",
                newName: "office");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "drivers",
                newName: "category_id");

            migrationBuilder.RenameIndex(
                name: "IX_drivers_CategoryId",
                table: "drivers",
                newName: "IX_drivers_category_id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_users_login",
                table: "users",
                column: "login");

            migrationBuilder.AddForeignKey(
                name: "FK_drivers_driver_categories_category_id",
                table: "drivers",
                column: "category_id",
                principalTable: "driver_categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_drivers_driver_categories_category_id",
                table: "drivers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_users_login",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "send_house",
                table: "orders",
                newName: "send_house_number");

            migrationBuilder.RenameColumn(
                name: "receive_house",
                table: "orders",
                newName: "receive_house_number");

            migrationBuilder.RenameColumn(
                name: "office",
                table: "legals",
                newName: "OfficeNumber");

            migrationBuilder.RenameColumn(
                name: "house",
                table: "legals",
                newName: "house_number");

            migrationBuilder.RenameColumn(
                name: "company",
                table: "legals",
                newName: "company_name");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "drivers",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_drivers_category_id",
                table: "drivers",
                newName: "IX_drivers_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_drivers_driver_categories_CategoryId",
                table: "drivers",
                column: "CategoryId",
                principalTable: "driver_categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
