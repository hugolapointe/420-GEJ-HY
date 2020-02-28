using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterExample.Infrastructure {
    public class ProfileAttribute : ActionFilterAttribute {

        private Stopwatch timer;
        private long actionElapsedTimeMs;

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, 
                                                          ActionExecutionDelegate next) {
            timer = Stopwatch.StartNew();

            await next();

            actionElapsedTimeMs = timer.ElapsedMilliseconds;
        }

        public override async Task OnResultExecutionAsync(ResultExecutingContext context,
                                                          ResultExecutionDelegate next) {
            await next();
            timer.Stop();

            string html = "";
            html += $"<div class=\"m-1 p-1\">";
            html += $"<span>Action time: {actionElapsedTimeMs} ms</span>";
            html += $"<span>Total time: {timer.Elapsed.TotalMilliseconds} ms</span>";
            html += $"</div>";

            byte[] bytes = Encoding.ASCII.GetBytes(html);
            await context.HttpContext.Response.Body.WriteAsync(bytes, 0, bytes.Length);
        }
    }
}
