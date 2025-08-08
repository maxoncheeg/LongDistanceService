using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LongDistanceService.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOrdersPersonalsRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "receiver_id",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "receiver_type",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "sender_id",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "sender_type",
                table: "orders");

            migrationBuilder.AddColumn<int>(
                name: "individual_receiver_id",
                table: "orders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "individual_sender_id",
                table: "orders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "legal_receiver_id",
                table: "orders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "legal_sender_id",
                table: "orders",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_individual_receiver_id",
                table: "orders",
                column: "individual_receiver_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_individual_sender_id",
                table: "orders",
                column: "individual_sender_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_legal_receiver_id",
                table: "orders",
                column: "legal_receiver_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_legal_sender_id",
                table: "orders",
                column: "legal_sender_id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_individuals_individual_receiver_id",
                table: "orders",
                column: "individual_receiver_id",
                principalTable: "individuals",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_individuals_individual_sender_id",
                table: "orders",
                column: "individual_sender_id",
                principalTable: "individuals",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_legals_legal_receiver_id",
                table: "orders",
                column: "legal_receiver_id",
                principalTable: "legals",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_legals_legal_sender_id",
                table: "orders",
                column: "legal_sender_id",
                principalTable: "legals",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_individuals_individual_receiver_id",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_individuals_individual_sender_id",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_legals_legal_receiver_id",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_legals_legal_sender_id",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_individual_receiver_id",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_individual_sender_id",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_legal_receiver_id",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_legal_sender_id",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "individual_receiver_id",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "individual_sender_id",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "legal_receiver_id",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "legal_sender_id",
                table: "orders");

            migrationBuilder.AddColumn<int>(
                name: "receiver_id",
                table: "orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "receiver_type",
                table: "orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "sender_id",
                table: "orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "sender_type",
                table: "orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
