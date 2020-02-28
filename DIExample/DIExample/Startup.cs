using DIExample.Context;
using DIExample.Domain.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace DIExample {
    public class Startup {
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddTransient<ProductRepository, InMemoryProductRepository>();
            //services.AddScoped<ProductRepository, InMemoryProductRepository>();
            //services.AddSingleton<ProductRepository, InMemoryProductRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();
        }
    }
}
