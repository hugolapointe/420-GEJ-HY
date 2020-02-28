using ContactManager.Data;
using ContactManager.Infrastructure;
using ContactManager.Models;
using ContactManager.ViewModels.Contact;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace ContactManager.Controllers {
    [Authorize]
    public class ContactController : Controller {
        private readonly AppDbContext context;

        public ContactController(AppDbContext context) {
            this.context = context;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Create(ContactDetailsViewModel model) {
            if (ModelState.IsValid) {
                return View(nameof(Index));
            }

            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            context.Contacts.Add(new ContactModel {
                Id = Guid.NewGuid(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                OwnerId = new Guid(userId)
            });

            context.SaveChanges();

            return View(nameof(Index));
        }

        [ContactOwner]
        public IActionResult Edit(Guid id, ContactDetailsViewModel model) {
            if (ModelState.IsValid) {
                return View(nameof(Index));
            }

            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var contact = context.Contacts.SingleOrDefault(c => c.Id == id);

            if (contact != null) {
                contact.FirstName = model.FirstName;
                contact.LastName = model.LastName;
                contact.Email = model.Email;

                context.SaveChanges();
            }

            return View(nameof(Index));
        }
    }
}