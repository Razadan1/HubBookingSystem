using HubBookingSystem.Data.Context;
using HubBookingSystem.Models;
using HubBookingSystem.Data;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace HubBookingSystem.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INotyfService _notyfService;
        public BookingController(ApplicationDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyfService = notyf;
        }
        public IActionResult Index()
        {
            IEnumerable<Booking> objBookingList = _context.Bookings;
            return View(objBookingList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Booking booking)
        {
            if(ModelState.IsValid)
            {
                _context.Bookings.Add(booking);
                _context.SaveChanges();
                _notyfService.Success("Booking created successfully");
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var bookingfromDb = _context.Bookings.Find(id);
            if(bookingfromDb == null)
            {
                _notyfService.Error("Id Not found!");
                return NotFound();
            }
            return View(bookingfromDb);
        }


        [HttpPost]
        public IActionResult Edit(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Bookings.Update(booking);
                _context.SaveChanges();
                _notyfService.Success("Booking Edited successfully");
                return RedirectToAction("Index");
            }
            return View(booking);

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var bookingFromDb = _context.Bookings.Find(id);
            if(bookingFromDb == null)
            {
                return NotFound();
            }
            return View(bookingFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var bookingFromDb = _context.Bookings.Find(id);
            if (bookingFromDb == null)
            {
                return NotFound();
            }
            _context.Bookings.Remove(bookingFromDb);
            _context.SaveChanges();
            _notyfService.Success("Booking deleted successfully");
            return RedirectToAction("Index");
         }

    }
}
