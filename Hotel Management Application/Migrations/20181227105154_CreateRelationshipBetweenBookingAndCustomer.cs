using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManagementApplication.Migrations
{
    public partial class CreateRelationshipBetweenBookingAndCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Bookings_BookingID",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "BookingID",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Bookings_BookingID",
                table: "Customers",
                column: "BookingID",
                principalTable: "Bookings",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Bookings_BookingID",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "BookingID",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Bookings_BookingID",
                table: "Customers",
                column: "BookingID",
                principalTable: "Bookings",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
