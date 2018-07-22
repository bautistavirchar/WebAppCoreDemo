﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAppCoreDemo.Data;
namespace WebAppCoreDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private string GetConnectionString
        {
            get{
                return Configuration.GetConnectionString("DefaultConnection");
            }
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(GetConnectionString));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 0;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            // services.ConfigureApplicationCookie(options =>
            // {
            //     // Cookie settings
            //     options.Cookie.HttpOnly = true;
            //     options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
            //     // If the LoginPath isn't set, ASP.NET Core defaults 
            //     // the path to /Account/Login.
            //     options.LoginPath = "/Account/Login";
            //     // If the AccessDeniedPath isn't set, ASP.NET Core defaults 
            //     // the path to /Account/AccessDenied.
            //     options.AccessDeniedPath = "/Account/AccessDenied";
            //     options.SlidingExpiration = true;
            // });


            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvcWithDefaultRoute();
        }
    }
}
