using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stripe;
using StripeDemo.Data;
using StripeDemo.Models;

namespace StripeDemo {
    public class Startup {
        private readonly IConfiguration config;

        public Startup(IConfiguration config) {
            this.config = config;
        }

        public void ConfigureServices(IServiceCollection services) {
            services.Configure<StripeOptions>(options =>
                config.GetSection("StripeTest").Bind(options)
            );

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
            );

            services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultTokenProviders();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                StripeConfiguration.SetApiKey(config.GetConnectionString("Stripe:TestSecretKey"));

                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseStatusCodePages();
            app.UseHttpsRedirection();
            app.UseMvcWithDefaultRoute();
        }
    }
}
