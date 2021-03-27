using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserActivitiesTestApp.Migrations
{
    public partial class randomUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RandomUrlStorage",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ActivityDateAdded = table.Column<DateTime>(nullable: false),
                    UrlString = table.Column<string>(nullable: true),
                    ShortUrl = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RandomUrlStorage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RandomUrlStorage_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RandomUrlStorage_UserId",
                table: "RandomUrlStorage",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RandomUrlStorage");
        }
    }
}
