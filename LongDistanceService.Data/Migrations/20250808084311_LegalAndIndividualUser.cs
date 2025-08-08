using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LongDistanceService.Data.Migrations
{
    /// <inheritdoc />
    public partial class LegalAndIndividualUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_personals");

            migrationBuilder.AddColumn<int>(
                name: "individual_id",
                table: "users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "legal_id",
                table: "users",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_individual_id",
                table: "users",
                column: "individual_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_legal_id",
                table: "users",
                column: "legal_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_users_individuals_individual_id",
                table: "users",
                column: "individual_id",
                principalTable: "individuals",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_legals_legal_id",
                table: "users",
                column: "legal_id",
                principalTable: "legals",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_individuals_individual_id",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_users_legals_legal_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_individual_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_legal_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "individual_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "legal_id",
                table: "users");

            migrationBuilder.CreateTable(
                name: "user_personals",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    personal_id = table.Column<int>(type: "integer", nullable: false),
                    personal_type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_personals", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_user_personals_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });
        }
    }
}
