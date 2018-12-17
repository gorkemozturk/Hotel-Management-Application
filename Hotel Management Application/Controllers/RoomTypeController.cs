using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagementApplication.Data;
using HotelManagementApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementApplication.Controllers
{
    public class RoomTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoomTypeController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // GET: RoomType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoomType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RoomType type)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                type.CreatedAt = DateTime.Now;

                _context.RoomTypes.Add(type);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Room");
            }
            catch
            {
                return View();
            }
        }

        // GET: RoomType/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            RoomType type = await _context.RoomTypes.FindAsync(id);

            if (type == null)
                return NotFound();

            return View(type);
        }

        // POST: RoomType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, RoomType type)
        {
            try
            {
                if (id != type.ID)
                    return NotFound();

                var existingType = await _context.RoomTypes.FindAsync(id);

                existingType.Name = type.Name;
                existingType.Price = type.Price;
                existingType.Tax = type.Tax;
                existingType.IsAvailable = type.IsAvailable;

                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Room");
            }
            catch
            {
                return View();
            }
        }
    }
}