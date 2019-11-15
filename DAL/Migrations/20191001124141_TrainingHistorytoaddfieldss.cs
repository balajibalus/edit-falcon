using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class TrainingHistorytoaddfieldss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AirplaneTrainingTime",
                table: "TrainingHistory",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "AirplaneTrainingTime",
                table: "TrainingHistory",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
