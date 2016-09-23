using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyHelper.Data.Migrations
{
    public partial class Family_Id_Allow_Nulls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Families_FamilyId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<long>(
                name: "FamilyId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Families_FamilyId",
                table: "AspNetUsers",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "family_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Families_FamilyId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<long>(
                name: "FamilyId",
                table: "AspNetUsers",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Families_FamilyId",
                table: "AspNetUsers",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "family_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
