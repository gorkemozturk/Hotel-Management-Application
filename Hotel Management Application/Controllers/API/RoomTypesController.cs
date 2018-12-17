using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagementApplication.Data;
using HotelManagementApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementApplication.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RoomTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                RoomType type = _context.RoomTypes.Find(id);

                if (type == null)
                    return BadRequest();

                _context.RoomTypes.Remove(type);
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
