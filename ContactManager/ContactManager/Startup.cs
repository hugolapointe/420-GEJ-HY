using ContactManager.Data;
using ContactManager.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ContactManager {
    public class Startup {
        private readonly IConfiguration config;

        public Startup(IConfiguration config) {
            this.config = config;
        }
        public void ConfigureServices(IServiceCollection services) {

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
            );

            services.AddIdentity<UserModel, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<AppDbContext>();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if(env.IsDevelopment()) {
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
