using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilterExample.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FilterExample {
    public class Startup {
        public void ConfigureServices(IServiceCollection services) {
            services.AddSingleton<TimeAverager>();
            services.AddMvc();
        }
        
        public void Configure(IApplicationBuilder app, 
                              IHostingEnvironment env) {
            if(env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseMvcWithDefaultRoute();
        }
    }
}
