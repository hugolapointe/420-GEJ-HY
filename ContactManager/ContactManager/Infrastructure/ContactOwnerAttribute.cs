using ContactManager.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Security.Claims;

namespace ContactManager.Infrastructure {
    public class ContactOwnerAttribute : Attribute, IFilterFactory {
        public bool IsReusable => false;

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider) {
            var context = (AppDbContext)serviceProvider.GetService(typeof(AppDbContext));

            return new ContactOwnerFilter(context);
        }

        private class ContactOwnerFilter : IActionFilter {
            private readonly AppDbContext appDbContext;

            public ContactOwnerFilter(AppDbContext context) {
                appDbContext = context;
            }

            public void OnActionExecuted(ActionExecutedContext context) {
                var contactId = new Guid(context.RouteData.Values["id"].ToString());
                var userId = new Guid(context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

                var contact = appDbContext.Contacts.SingleOrDefault(c => c.Id == contactId);

                if (contact == null || contact.OwnerId != userId) {
                    context.ModelState.AddModelError("", "You must be owner of the contact.");
                }
            }

            public void OnActionExecuting(ActionExecutingContext context) {
            }
        }
    }
}
