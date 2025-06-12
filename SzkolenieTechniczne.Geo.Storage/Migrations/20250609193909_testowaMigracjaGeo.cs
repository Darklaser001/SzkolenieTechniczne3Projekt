using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SzkolenieTechniczne.Geo.Storage.Migrations
{
    /// <inheritdoc />
    public partial class testowaMigracjaGeo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Geo");

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "Geo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Alpha3Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "Geo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Geo",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryTransaltions",
                schema: "Geo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTransaltions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryTransaltions_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Geo",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CityTranslations",
                schema: "Geo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityTranslations_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "Geo",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                schema: "Geo",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CityTranslations_CityId",
                schema: "Geo",
                table: "CityTranslations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CityTranslations_LanguageCode",
                schema: "Geo",
                table: "CityTranslations",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_CityTranslations_Name",
                schema: "Geo",
                table: "CityTranslations",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Alpha3Code",
                schema: "Geo",
                table: "Countries",
                column: "Alpha3Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CountryTransaltions_CountryId",
                schema: "Geo",
                table: "CountryTransaltions",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryTransaltions_LanguageCode",
                schema: "Geo",
                table: "CountryTransaltions",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_CountryTransaltions_Name",
                schema: "Geo",
                table: "CountryTransaltions",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityTranslations",
                schema: "Geo");

            migrationBuilder.DropTable(
                name: "CountryTransaltions",
                schema: "Geo");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "Geo");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "Geo");
        }
    }
}
