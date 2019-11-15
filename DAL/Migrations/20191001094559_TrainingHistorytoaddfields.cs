using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class TrainingHistorytoaddfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TrainingHistory",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "TrainingHistory",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RingNumber",
                table: "TrainingHistory",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TrainingHistory",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "TrainingHistory",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TrainingHistory");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "TrainingHistory");

            migrationBuilder.DropColumn(
                name: "RingNumber",
                table: "TrainingHistory");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TrainingHistory");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "TrainingHistory");
        }
    }
}
