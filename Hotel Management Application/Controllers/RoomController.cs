using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagementApplication.Data;
using HotelManagementApplication.Models;
using HotelManagementApplication.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementApplication.Controllers
{
    [Authorize]
    public class RoomController : Controller
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public RoomViewModel Model { get; set; }

        public RoomController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            Model = new RoomViewModel()
            {
                Rooms = await _context.Rooms.Include(r => r.RoomType).ToListAsync(),
                Types = await _context.RoomTypes.ToListAsync()
            };

            return View(Model);
        }

        public async Task<IActionResult> Create()
        {
            Model = new RoomViewModel()
            {
                Types = await _context.RoomTypes.ToListAsync()
            };

            return View(Model);
        }

        [HttpPost, ActionName(nameof(Create))]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Store()
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                Model.Room.CreatedAt = DateTime.Now;

                _context.Rooms.Add(Model.Room);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Room/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            Model = new RoomViewModel()
            {
                Types = await _context.RoomTypes.ToListAsync()
            };

            if (id == null)
                return NotFound();

            Model.Room = await _context.Rooms.FindAsync(id);

            if (Model.Room == null)
                return NotFound();

            return View(Model);
        }

        // POST: Room/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                Room room = await _context.Rooms.FindAsync(id);

                room.RoomNumber = Model.Room.RoomNumber;
                room.IsAvailable = Model.Room.IsAvailable;

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