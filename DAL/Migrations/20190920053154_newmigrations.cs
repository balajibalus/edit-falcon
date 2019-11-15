using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class newmigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Falcon");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Falcon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BackImage = table.Column<string>(nullable: true),
                    ChipNumber = table.Column<string>(nullable: true),
                    ColorsId = table.Column<int>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Documents = table.Column<string>(nullable: true),
                    FrontImage = table.Column<string>(nullable: true),
                    GenderId = table.Column<int>(nullable: true),
                    GiftedTo = table.Column<string>(nullable: true),
                    Length = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    RingNumber = table.Column<string>(nullable: true),
                    ScientificNameId = table.Column<int>(nullable: true),
                    SeasonsId = table.Column<int>(nullable: true),
                    SpeciesId = table.Column<int>(nullable: true),
                    StatusId = table.Column<int>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    Weight = table.Column<string>(nullable: true),
                    Width = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Falcon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Falcon_Colors_ColorsId",
                        column: x => x.ColorsId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Falcon_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Falcon_ScientificNames_ScientificNameId",
                        column: x => x.ScientificNameId,
                        principalTable: "ScientificNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Falcon_Seasons_SeasonsId",
                        column: x => x.SeasonsId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Falcon_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Falcon_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Falcon_ColorsId",
                table: "Falcon",
                column: "ColorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Falcon_GenderId",
                table: "Falcon",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Falcon_ScientificNameId",
                table: "Falcon",
                column: "ScientificNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Falcon_SeasonsId",
                table: "Falcon",
                column: "SeasonsId");

            migrationBuilder.CreateIndex(
                name: "IX_Falcon_SpeciesId",
                table: "Falcon",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Falcon_StatusId",
                table: "Falcon",
                column: "StatusId");
        }
    }
}
