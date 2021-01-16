using Microsoft.EntityFrameworkCore.Migrations;

namespace CyclingCalendar.WebApp.Migrations
{
    public partial class CalendarEventActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Events");
        }
    }
}
