using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterExample.Infrastructure {
    public class ViewResultDetailsAttribute : ResultFilterAttribute {

        public async override Task OnResultExecutionAsync(ResultExecutingContext context,
                                                          ResultExecutionDelegate next) {
            Dictionary<string, string> details = new Dictionary<string, string> {
                ["Result Type"] = context.Result.GetType().Name,
            };

            ViewResult viewResult = context.Result as ViewResult;
            if(viewResult != null) {
                details["View Name"] = viewResult.ViewName;
                details["Model Type"] = viewResult.ViewData.Model?.GetType().Name;
                details["Model Data"] = viewResult.ViewData.Model?.ToString();
            }

            context.Result = new ViewResult {
                ViewData = new ViewDataDictionary(
                    new EmptyModelMetadataProvider(),
                    new ModelStateDictionary()) { Model = details }
            };

            await next();
        }
    }
}
