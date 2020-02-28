using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MVExample.Models;
using Newtonsoft.Json;

namespace MVExample.Controllers {
    public class HomeController : Controller {

        public IActionResult Index() {
            return RedirectToAction(nameof(MakeBooking));
        }

        public IActionResult MakeBooking() {
            return View(new Appointment { Date = DateTime.Now });
        }

        [HttpPost]
        public IActionResult MakeBooking(Appointment appt) {
            //if (string.IsNullOrEmpty(appt.ClientName)) {
            //    ModelState.AddModelError(nameof(appt.ClientName), "Please enter a name.");
            //}

            //if (appt.Date < DateTime.Now) {
            //    ModelState.AddModelError(nameof(appt.Date), "Please enter a date in the future.");
            //}

            //if (!appt.TermsAccepted) {
            //    ModelState.AddModelError(nameof(appt.TermsAccepted), "Please accept the terms.");
            //}

            if(!ModelState.IsValid) {
                return View();
            }

            TempData["appt"] = JsonConvert.SerializeObject(appt);

            return RedirectToAction(nameof(ConfirmBooking));
        }

        public IActionResult ConfirmBooking() {
            Appointment appt = JsonConvert.DeserializeObject<Appointment>((string)TempData["appt"]);

            return View(appt);
        }
        
        public JsonResult ValidateDate(string Date) {
            DateTime parsedDate;
            if(!DateTime.TryParse(Date, out parsedDate)) {
                return Json("Please enter a valid date (mm/dd/yyyy).");
            } else if(DateTime.Now >= parsedDate) {
                return Json("Please enter a date in the future.");
            } else {
                return Json(true);
            }
        }
    }
}