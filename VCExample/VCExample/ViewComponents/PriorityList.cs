using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VCExample.Models;

namespace VCExample.ViewComponents {
    public class PriorityList : ViewComponent {
        private readonly ToDoContext context;

        public PriorityList(ToDoContext context) {
            this.context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int maxPriority, bool isDone) {
            var items = await GetItemsToDisplayAsync(maxPriority, isDone);

            return View(items);
        }

        private Task<List<ToDo>> GetItemsToDisplayAsync(int maxPriority, bool isDone) {
            return context.ToDo
                .Where(item => item.Priority <= maxPriority && 
                               item.IsDone == isDone)
                .ToListAsync();
        }
    }
}
