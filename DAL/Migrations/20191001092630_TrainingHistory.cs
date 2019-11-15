using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class TrainingHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainingHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Weight = table.Column<string>(nullable: true),
                    AirplaneTrainingSpeed = table.Column<string>(nullable: true),
                    AirplaneTrainingDistane = table.Column<string>(nullable: true),
                    AirplaneTrainingTime = table.Column<DateTime>(nullable: false),
                    HubaraTraining = table.Column<string>(nullable: true),
                    HubaraHumality = table.Column<string>(nullable: true),
                    Timinings = table.Column<DateTime>(nullable: false),
                    Data = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingHistory", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingHistory");
        }
    }
}
