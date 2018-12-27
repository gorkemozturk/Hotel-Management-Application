using HotelManagementApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementApplication.Services
{
    public class BookingService
    {
        private readonly ApplicationDbContext _context;

        public BookingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool IsPaid(int id)
        {
            var remainingAmount = _context.Bookings.Where(b => b.ID == id).Select(b => b.RemainingAmount).FirstOrDefault();

            if (remainingAmount == 0 || remainingAmount <= 0)
                return true;
            else
                return false;
        }
    }
}
