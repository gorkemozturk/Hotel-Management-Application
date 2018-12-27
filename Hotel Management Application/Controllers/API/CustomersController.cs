using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagementApplication.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementApplication.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customers = _context.BookingGuests.Where(b => b.BookingID == id).Select(b => new {
                fullName = b.FirstName + " " + b.LastName,
                phoneNumber = b.PhoneNumber,
                city = b.City,
            }).ToList();

            if (customers == null)
                return BadRequest();

            return Ok(customers);
        }
    }
}