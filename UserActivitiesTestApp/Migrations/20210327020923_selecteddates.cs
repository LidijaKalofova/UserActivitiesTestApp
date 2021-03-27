using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserActivitiesTestApp.Migrations
{
    public partial class selecteddates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SelectedDateFrom",
                table: "RandomUrlStorage",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SelectedDateTo",
                table: "RandomUrlStorage",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectedDateFrom",
                table: "RandomUrlStorage");

            migrationBuilder.DropColumn(
                name: "SelectedDateTo",
                table: "RandomUrlStorage");
        }
    }
}
