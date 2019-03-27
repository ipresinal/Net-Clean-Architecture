using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Gav.IdentityDemo.Data;
using Gav.IdentityDemo.Models;
using Gav.IdentityDemo.Policies;
using Gav.IdentityDemo.Services;
using Microsoft.AspNetCore.Authorization;

namespace Gav.IdentityDemo
{
    public class Startup
    {
        public const int requiredLenghtForPassword = 6;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    options.Lockout.MaxFailedAccessAttempts = 10;

                    options.Password.RequiredLength = requiredLenghtForPassword;
                    options.Password.RequiredUniqueChars = 3;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = true;

                    options.User.RequireUniqueEmail = true;

                    
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders()
                .AddErrorDescriber<MyErrorDescriber>();

            services.AddAuthorization(options =>
                {
                    options.AddPolicy("PolicyCategoriaEmpleado", 
                        pol => pol.Requirements.Add(new CategoriaEmpleadorequirement()));
                });

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddSingleton<IAuthorizationHandler, CategoriaEmpleadoHandler>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
