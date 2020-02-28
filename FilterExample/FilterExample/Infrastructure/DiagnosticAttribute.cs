using FilterExample.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FilterExample.Infrastructure {
    public class DiagnosticAttribute : Attribute, IFilterFactory {
        public bool IsReusable => true;

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider) {
            TimeAverager averager = (TimeAverager)serviceProvider.GetService(typeof(TimeAverager));

            return new DiagnosticFilter(averager);
        }

        private class DiagnosticFilter : IAsyncResultFilter, IAsyncActionFilter {

            private readonly TimeAverager averager;
            private Stopwatch timer;

            public DiagnosticFilter(TimeAverager averager) {
                this.averager = averager;
            }

            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) {
                timer = Stopwatch.StartNew();

                await next();
            }

            public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next) {
                await next();
                timer.Stop();

                averager.addTime(timer.ElapsedMilliseconds);
            }
        }
    }
}
