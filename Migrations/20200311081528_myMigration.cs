using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WaterMS.Migrations
{
    public partial class myMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date_deactivated",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "deactivated_by",
                table: "Books");

            migrationBuilder.AddColumn<DateTime>(
                name: "date_updated",
                table: "Books",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date_updated",
                table: "Books");

            migrationBuilder.AddColumn<DateTime>(
                name: "date_deactivated",
                table: "Books",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "deactivated_by",
                table: "Books",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
