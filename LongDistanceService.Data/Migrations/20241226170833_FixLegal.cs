﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LongDistanceService.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixLegal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "company",
                table: "legals",
                type: "character varying(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "company",
                table: "legals",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(32)",
                oldMaxLength: 32);
        }
    }
}
