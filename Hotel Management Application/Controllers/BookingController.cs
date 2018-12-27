using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagementApplication.Data;
using HotelManagementApplication.Models;
using HotelManagementApplication.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementApplication.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public BookingViewModel Model { get; set; }

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Booking
        public async Task<ActionResult> Index()
        {
            return View(await _context.Bookings.Include(b => b.RoomType).Include(b => b.Guests).ToListAsync());
        }

        // GET: Booking/Create
        public async Task<ActionResult> Create()
        {
            Model = new BookingViewModel()
            {
                Booking = new Booking(),
                Types = await _context.RoomTypes.ToListAsync()
            };

            return View(Model);
        }

        // POST: Booking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Booking booking)
        {
            try
            {
                if (!ModelState.IsValid)
                    return NotFound();

                var type = await _context.RoomTypes.FindAsync(booking.RoomTypeID);

                booking.RemainingAmount = ((type.Price + (type.Price * type.Tax / 100)) * booking.Duration * booking.Capacity) - booking.Payment;
                booking.CreatedAt = DateTime.Now;

                _context.Bookings.Add(booking);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/AddGuest/5
        public async Task<ActionResult> AddGuest(int? id)
        {
            if (id == null)
                return NotFound();

            BookingGuestViewModel model = new BookingGuestViewModel()
            {
                Booking = await _context.Bookings.FindAsync(id),
                Guest = new BookingGuest()
            };

            if (model.Booking == null)
                return NotFound();

            return View(model);
        }

        // POST: Customer/AddGuest/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddGuest(int id, BookingGuestViewModel model)
        {
            try
            {
                var booking = _context.Bookings.Find(id);

                model.Guest.BookingID = booking.ID;

                _context.BookingGuests.Add(model.Guest);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}