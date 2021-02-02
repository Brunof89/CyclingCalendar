using Microsoft.EntityFrameworkCore.Migrations;

namespace CyclingCalendar.WebApp.Migrations
{
    public partial class CalendarEventAddOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Events");
        }
    }
}
