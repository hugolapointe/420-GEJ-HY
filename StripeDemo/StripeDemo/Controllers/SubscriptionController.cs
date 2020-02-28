using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;
using StripeDemo.Models;
using System.Collections.Generic;

namespace StripeDemo.Controllers {
    public class SubscriptionController : Controller {
        private readonly IOptions<StripeOptions> stripeOptions;

        readonly ProductModel rubberducks = new ProductModel {
            Name = "Rubberduck",
            Price = 10
        };

        public SubscriptionController(IOptions<StripeOptions> stripeOptions) {
            this.stripeOptions = stripeOptions;
        }

        public IActionResult Index() {
            return View(rubberducks);
        }

        [HttpPost]
        public JsonResult Charges([FromBody] ChargesModel model) {
            StripeConfiguration.SetApiKey(stripeOptions.Value.SecretKey);

            var customers = new CustomerService();
            var charges = new ChargeService();
            var subscriptions = new SubscriptionService();
            var products = new ProductService();
            var plans = new PlanService();

            var customer = customers.Create(new CustomerCreateOptions {
                Email = model.Email,
                SourceToken = model.Token
            });

            var charge = charges.Create(new ChargeCreateOptions {
                Amount = model.AmountInCents,
                Description = model.Description,
                Currency = "cad",
                CustomerId = customer.Id
            });

            var product = products.Create(new ProductCreateOptions() {
                Name = "Rubberduck delivery",
                Type = "service"
            });

            var plan = plans.Create(new PlanCreateOptions() {
                Amount = model.AmountInCents,
                Interval = "month",
                Currency = model.CurrencyCode,
                ProductId = product.Id
            });

            var items = new List<SubscriptionItemOption> {
                  new SubscriptionItemOption {
                    PlanId = plan.Id
                  }
            };

            var subscription = subscriptions.Create(new SubscriptionCreateOptions() {
                CustomerId = customer.Id,
                Items = items
            });

            return Json(subscription.ToJson());
        }
    }
}