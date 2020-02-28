using BookingManager.Persistance;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookingManager {
    public class Startup {
        private readonly IConfiguration config;

        public Startup(IConfiguration config) {
            this.config = config;
        }

        public void ConfigureServices(IServiceCollection services) {
            services.AddSession();
            services.AddMvc();

            services.AddDbContext<BookingDbContext>(options => {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvcWithDefaultRoute();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
        }
    }
}
