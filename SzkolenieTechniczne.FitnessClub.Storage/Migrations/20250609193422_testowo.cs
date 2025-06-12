using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SzkolenieTechniczne.FitnessClub.Storage.Migrations
{
    /// <inheritdoc />
    public partial class testowo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactTypeTranslations",
                schema: "Dictionaries");

            migrationBuilder.DropTable(
                name: "ContactTypes",
                schema: "Dictionaries");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactTypes",
                schema: "Dictionaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactTypeTranslations",
                schema: "Dictionaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactTypeId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactTypeId = table.Column<long>(type: "bigint", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactTypeTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactTypeTranslations_ContactTypes_ContactTypeId1",
                        column: x => x.ContactTypeId1,
                        principalSchema: "Dictionaries",
                        principalTable: "ContactTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactTypeTranslations_ContactTypeId1",
                schema: "Dictionaries",
                table: "ContactTypeTranslations",
                column: "ContactTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_ContactTypeTranslations_LanguageCode",
                schema: "Dictionaries",
                table: "ContactTypeTranslations",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_ContactTypeTranslations_Name",
                schema: "Dictionaries",
                table: "ContactTypeTranslations",
                column: "Name");
        }
    }
}
