using Microsoft.AspNetCore.Mvc;
using System.Linq;
using VCExample.Models;

namespace VCExample.Controllers {
    public class ToDoController : Controller {
        private readonly ToDoContext context;

        public ToDoController(ToDoContext context) {
            this.context = context;
        }

        public IActionResult Index() {
            return View(context.ToDo.ToList());
        }
    }
}