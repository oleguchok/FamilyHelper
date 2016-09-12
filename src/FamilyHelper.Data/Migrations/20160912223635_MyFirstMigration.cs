using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FamilyHelper.Data.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    family_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FamilyName = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => x.family_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FamilyId = table.Column<long>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    HashedPassword = table.Column<string>(maxLength: 450, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    UserName = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Families_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Families",
                        principalColumn: "family_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Families_FamilyName",
                table: "Families",
                column: "FamilyName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_FamilyId",
                table: "Users",
                column: "FamilyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Families");
        }
    }
}
