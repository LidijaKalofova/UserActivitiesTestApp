using Microsoft.EntityFrameworkCore.Migrations;

namespace UserActivitiesTestApp.Migrations
{
    public partial class sec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ActivityTimeSpent",
                table: "Activity",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ActivityTimeSpent",
                table: "Activity",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
