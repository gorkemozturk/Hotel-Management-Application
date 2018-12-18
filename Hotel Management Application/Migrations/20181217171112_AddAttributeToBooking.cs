﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManagementApplication.Migrations
{
    public partial class AddAttributeToBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Bookings",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Bookings");
        }
    }
}
