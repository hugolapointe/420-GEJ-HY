using ContactManager.Data;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.ViewComponents {
    public class ContactListViewComponent : ViewComponent {
        private readonly AppDbContext context;

        public ContactListViewComponent(AppDbContext context) {
            this.context = context;
        }

        public IViewComponentResult Invoke() {
            return View(context.Contacts);
        }
    }
}
