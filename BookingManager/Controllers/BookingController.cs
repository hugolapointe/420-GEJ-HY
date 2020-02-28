using System;

using BookingManager.Domain.Models;
using BookingManager.Persistance;
using BookingManager.ViewModels.Booking;

using Microsoft.AspNetCore.Mvc;

namespace BookingManager.Controllers {
    public class BookingController : Controller {
        private readonly BookingDbContext context;

        public BookingController(BookingDbContext context) {
            this.context = context;
        }

        public IActionResult Create() {
            return View(new BookingCreation() {
                Date = DateTime.Now
            });
        }

        [HttpPost]
        public IActionResult Create(BookingCreation booking) {
            if (!ModelState.IsValid) {
                return View();
            }

            var appt = new Appointment() {
                ClientName = booking.ClientName,
                ClientPhoneNumber = booking.ClientPhoneNumber,
                ClientEmailAddress = booking.ClientEmailAddress,
                Date = booking.Date,
                CreationDate = DateTime.Now
            };
            context.Appointments.Add(appt);
            context.SaveChanges();

            return RedirectToAction("Details", new { id = appt.Id });
        }

        public IActionResult Details(Guid id) {
            var appt = context.Appointments.Find(id);

            return View(new BookingDetails() {
                ClientName = appt.ClientName,
                ClientPhoneNumber = appt.ClientPhoneNumber,
                ClientEmailAddress = appt.ClientEmailAddress,
                Date = appt.Date
            });
        }
    }
}