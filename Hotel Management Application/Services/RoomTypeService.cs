using HotelManagementApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementApplication.Services
{
    public class RoomTypeService
    {
        private readonly ApplicationDbContext _context;

        public RoomTypeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public string IsUsed(int id)
        {
            var count = _context.Rooms.Where(r => r.RoomTypeID == id).ToList().Count();

            if (count == 0)
                return "Unused";
            else
                return "Used";
        }
    }
}
