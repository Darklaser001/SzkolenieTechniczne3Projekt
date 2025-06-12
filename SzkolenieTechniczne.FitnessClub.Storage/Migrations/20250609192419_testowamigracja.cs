using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SzkolenieTechniczne.FitnessClub.Storage.Migrations
{
    /// <inheritdoc />
    public partial class testowamigracja : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Dictionaries");

            migrationBuilder.EnsureSchema(
                name: "Fitness");

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
                name: "Countries",
                schema: "Dictionaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Alpha3Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    ExternalSourceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExternalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastSynchronizedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FitnessClubs",
                schema: "Fitness",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PhonePrefix = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    VATNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessClubs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactTypeTranslations",
                schema: "Dictionaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ContactTypeId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
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

            migrationBuilder.CreateTable(
                name: "CountryTranslations",
                schema: "Dictionaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryTranslations_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Dictionaries",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FitnessClubAddresses",
                schema: "Fitness",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FitnessClubId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Post = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Province = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    District = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Community = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    City = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    FlatNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    HouseNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessClubAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FitnessClubAddresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Dictionaries",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FitnessClubAddresses_FitnessClubs_FitnessClubId",
                        column: x => x.FitnessClubId,
                        principalSchema: "Fitness",
                        principalTable: "FitnessClubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffMembers",
                schema: "Fitness",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FitnessClubId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    WorkingHours = table.Column<short>(type: "smallint", nullable: true),
                    GrossSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WorkingWeekHours = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffMembers_FitnessClubs_FitnessClubId",
                        column: x => x.FitnessClubId,
                        principalSchema: "Fitness",
                        principalTable: "FitnessClubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffMemberTranslations",
                schema: "Fitness",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StaffMemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Responsibilities = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    LanguageCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffMemberTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffMemberTranslations_StaffMembers_StaffMemberId",
                        column: x => x.StaffMemberId,
                        principalSchema: "Fitness",
                        principalTable: "StaffMembers",
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

            migrationBuilder.CreateIndex(
                name: "IX_CountryTranslations_CountryId",
                schema: "Dictionaries",
                table: "CountryTranslations",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryTranslations_LanguageCode",
                schema: "Dictionaries",
                table: "CountryTranslations",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessClubAddresses_CountryId",
                schema: "Fitness",
                table: "FitnessClubAddresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessClubAddresses_FitnessClubId",
                schema: "Fitness",
                table: "FitnessClubAddresses",
                column: "FitnessClubId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StaffMembers_FitnessClubId",
                schema: "Fitness",
                table: "StaffMembers",
                column: "FitnessClubId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffMemberTranslations_LanguageCode",
                schema: "Fitness",
                table: "StaffMemberTranslations",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_StaffMemberTranslations_StaffMemberId",
                schema: "Fitness",
                table: "StaffMemberTranslations",
                column: "StaffMemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactTypeTranslations",
                schema: "Dictionaries");

            migrationBuilder.DropTable(
                name: "CountryTranslations",
                schema: "Dictionaries");

            migrationBuilder.DropTable(
                name: "FitnessClubAddresses",
                schema: "Fitness");

            migrationBuilder.DropTable(
                name: "StaffMemberTranslations",
                schema: "Fitness");

            migrationBuilder.DropTable(
                name: "ContactTypes",
                schema: "Dictionaries");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "Dictionaries");

            migrationBuilder.DropTable(
                name: "StaffMembers",
                schema: "Fitness");

            migrationBuilder.DropTable(
                name: "FitnessClubs",
                schema: "Fitness");
        }
    }
}
