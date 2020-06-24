using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaWebApp.Migrations
{
    public partial class _2nuevascolumnas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Libros",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Libros",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Libros");
        }
    }
}
