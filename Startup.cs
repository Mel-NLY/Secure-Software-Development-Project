using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SSDAssignmentBOX.Models;
using Microsoft.AspNetCore.Identity;

namespace SSDAssignmentBOX
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        #region snippet_ConfigureServices
        public void ConfigureServices(IServiceCollection services)
        { 
            services.AddDbContext<BookContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("BookContext")));

            //ConfigureServices() method calls AddIdentity() method to add ASP.NET Core Identity services to the container. This is where ApplicationUser and IdentityRole classes are also mentioned.
            //The following code register the context and identity to Dependency Injection during the Application start up. Register these as a Service in the ConfigureServices method of the StartUp class,
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<BookContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            { // Password settings. Password, lockout and user settings can be configured.
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 12;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings 
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.AllowedForNewUsers = true;

                // User settings 
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // options.Cookie.Name = "YourCookieName";
                // options.Cookie.Domain=
                // options.LoginPath = "/Account/Login";
                // options.LogoutPath = "/Account/Logout";
                // options.AccessDeniedPath = "/Account/AccessDenied";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromSeconds(300);
                options.SlidingExpiration = true;
            });


            //Use of authorization filters - AuthorizePage(), AuthorizeFolder(), AllowAnonymousToPage() and AllowAnonymousToFolder() methods at startup to control access.
            //AuthorizeFolder method to restrict access to a folder and all of its contents.
            //AuthorizePage method to restrict access on a page-by-page basis.
            services.AddMvc().AddRazorPagesOptions(options => 
            {
                //options.Conventions.AllowAnonymousToFolder("/Books"); 
                options.Conventions.AuthorizePage("/Books/Create");
                options.Conventions.AuthorizePage("/Account/Create");
            });
        }
        #endregion

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseStatusCodePages("text/html", "<h1>Status code page</h1> <h2>Status Code: {0}</h2> <br> <a href='/Index'>Go back to Mainpage</a>");
            app.UseExceptionHandler("/Error");
            app.UseHsts();
            /*if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("~/Error");
                app.UseHsts();
            }*/
            /*
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //When exception occurs, route to Error page in the Pages folder
                app.UseStatusCodePages("text/html", "<h1>Status code page</h1> <h2>Status Code: {0}</h2> <br> <a href='/Index'>Go back to Mainpage</a>");
                app.UseExceptionHandler("/Error");
            }*/
            app.UseStaticFiles();
            app.UseAuthentication(); //Configure() method calls UserAuthentication() method to add ASP.NET Core Identity to the request pipeline.
            app.UseMvc();
        }
    }
}
