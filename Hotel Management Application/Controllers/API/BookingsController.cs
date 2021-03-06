﻿using HotelManagementApplication.Data;
using HotelManagementApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HotelManagementApplication.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var booking = _context.Bookings.Where(b => b.ID == id).Include(b => b.RoomType).Select(b => new {
                bookingName = b.BookingName,
                roomType = b.RoomType.Name,
                duration = b.Duration,
                capacity = b.Capacity,
                payment = b.Payment,
                remainingAmount = b.RemainingAmount,
                startOn = b.StartOn,
                createdAt = b.CreatedAt
            });

            if (booking == null)
                return BadRequest();

            return Ok(booking);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Booking booking = _context.Bookings.Find(id);

                if (booking == null)
                    return BadRequest();

                _context.Bookings.Remove(booking);
                _context.SaveChanges();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
