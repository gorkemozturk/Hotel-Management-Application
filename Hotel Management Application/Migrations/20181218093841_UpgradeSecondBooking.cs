using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManagementApplication.Migrations
{
    public partial class UpgradeSecondBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Bookings",
                newName: "StartOn");

            migrationBuilder.AddColumn<string>(
                name: "BookingName",
                table: "Bookings",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingName",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "StartOn",
                table: "Bookings",
                newName: "StartDate");
        }
    }
}
