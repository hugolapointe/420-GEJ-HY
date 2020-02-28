using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;
using StripeDemo.Models;

namespace StripeDemo.Controllers {
    [Authorize]
    public class PaymentController : Controller {
        private readonly IOptions<StripeOptions> stripeOptions;

        readonly ProductModel rubberducks = new ProductModel {
            Name = "Rubberduck",
            Price = 10
        };

        public PaymentController(IOptions<StripeOptions> stripeOptions) {
            this.stripeOptions = stripeOptions;
        }

        public IActionResult RequestButton() {
            return View(rubberducks);
        }

        public IActionResult Elements() {
            return View(rubberducks);
        }

        [HttpPost]
        public JsonResult Charges([FromBody] ChargesModel model) {
            StripeConfiguration.SetApiKey(stripeOptions.Value.SecretKey);

            var options = new ChargeCreateOptions {
                Amount = model.AmountInCents,
                Description = model.Description,
                SourceId = model.Token,
                Currency = model.CurrencyCode
            };
            var service = new ChargeService();
            Charge charge = service.Create(options);

            return Json(charge.ToJson());
        }

        public IActionResult Confirmation() {
            return View();
        }
    }
}