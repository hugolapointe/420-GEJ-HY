using System;
using Microsoft.AspNetCore.Mvc;

namespace BookingManager.Controllers {
    public class ValidateController : Controller {

        public JsonResult IsDateInFuture(string Date) {
            if (!DateTime.TryParse(Date, out DateTime parsedDate)) {
                return Json("Please enter a valid date (mm/dd/yyyy).");
            }

            if (DateTime.Now >= parsedDate) {
                return Json("Please enter a future date.");
            }

            return Json(true);
        }
    }
}