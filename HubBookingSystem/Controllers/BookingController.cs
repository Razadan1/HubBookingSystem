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
            List<Booking> objBookingList = _context.Bookings.ToList();
            return View(objBookingList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Booking obj)
        {
         
                _context.Bookings.Add(obj);
                _context.SaveChanges();
                _notyfService.Success("Booking created successfully");
                return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Booking bookingfromDb = _context.Bookings.Find(id);
            if(bookingfromDb == null)
            {
                _notyfService.Error("Id Not found!");
                return NotFound();
            }
            return View(bookingfromDb);
        }

        [HttpPost]
        public IActionResult Edit(Booking obj)
        {
            if (ModelState.IsValid)
            {
                _context.Bookings.Update(obj);
                _context.SaveChanges();
                _notyfService.Success("Booking Edited successfully");
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View( );
        }

        [HttpDelete,  ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Booking? obj = _context.Bookings.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _context.Bookings.Remove(obj);
            _context.SaveChanges();
            _notyfService.Success("Booking deleted successfully");
            return RedirectToAction("Index");
         }

    }
}
