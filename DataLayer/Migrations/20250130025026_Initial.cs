using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactGroups",
                columns: table => new
                {
                    ContactGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactGroups", x => x.ContactGroupId);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    CampaignId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Contents = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberContactsTargeted = table.Column<int>(type: "int", nullable: false),
                    TargetGroupContactGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.CampaignId);
                    table.ForeignKey(
                        name: "FK_Campaigns_ContactGroups_TargetGroupContactGroupId",
                        column: x => x.TargetGroupContactGroupId,
                        principalTable: "ContactGroups",
                        principalColumn: "ContactGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactContactGroup",
                columns: table => new
                {
                    ContactGroupsContactGroupId = table.Column<int>(type: "int", nullable: false),
                    ContactsContactId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactContactGroup", x => new { x.ContactGroupsContactGroupId, x.ContactsContactId });
                    table.ForeignKey(
                        name: "FK_ContactContactGroup_ContactGroups_ContactGroupsContactGroupId",
                        column: x => x.ContactGroupsContactGroupId,
                        principalTable: "ContactGroups",
                        principalColumn: "ContactGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactContactGroup_Contacts_ContactsContactId",
                        column: x => x.ContactsContactId,
                        principalTable: "Contacts",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_TargetGroupContactGroupId",
                table: "Campaigns",
                column: "TargetGroupContactGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactContactGroup_ContactsContactId",
                table: "ContactContactGroup",
                column: "ContactsContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactGroups_Name",
                table: "ContactGroups",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "ContactContactGroup");

            migrationBuilder.DropTable(
                name: "ContactGroups");

            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
