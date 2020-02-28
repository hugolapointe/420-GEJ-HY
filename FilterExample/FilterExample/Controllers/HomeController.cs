using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilterExample.Infrastructure;
using FilterExample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilterExample.Controllers {

    public class HomeController : Controller {
        private readonly TimeAverager averager;

        public HomeController(TimeAverager averager) {
            this.averager = averager;
        }


        [Profile]
        [ViewResultDetails]
        [DiagnosticAttribute]
        public IActionResult Index() {
            double avg = averager.CalculateAverage();

            return base.View("Index", $"{avg:F2} ms");
        }
    }
}