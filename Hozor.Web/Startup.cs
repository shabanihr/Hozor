using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GSD.Globalization;
using Hozor.DataLayer.Models;
using Hozor.Servises.Repositoryes.Public;
using Hozor.Servises.Services.Public;
using Hozor.Utilities.Middelware;
using Hozor.Web.Filters;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hozor.Web
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.Filters.Add(typeof(DynamicAuthorizationFilter)));
            services.AddDbContext<Hozor_DBContext>(options =>
                            options.UseSqlServer(Configuration.GetConnectionString("HozorDbContext")));



            services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.AccessDeniedPath = "/you-are-not-allowed-page";
                    options.LoginPath = "/Login";
                    



                });

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //}).AddCookie(options => { options.LoginPath = "/Login"; });
            //services.AddMvc().AddRazorPagesOptions(options =>
            //{
            //    options.Conventions.AuthorizeFolder("/");
            //    options.Conventions.AllowAnonymousToPage("/Login");
            //});


            //services.Configure<IdentityOptions>(options =>
            //{
            //    // Password settings  
            //    options.Password.RequireDigit = true;
            //    options.Password.RequiredLength = 8;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequireUppercase = true;
            //    options.Password.RequireLowercase = false;
            //    options.Password.RequiredUniqueChars = 6;

            //    // Lockout settings  
            //    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            //    options.Lockout.MaxFailedAccessAttempts = 10;
            //    options.Lockout.AllowedForNewUsers = true;

            //    // User settings  
            //    options.User.RequireUniqueEmail = true;
            //});

            ////Seting the Account Login page  
            //services.ConfigureApplicationCookie(options =>
            //{
            //    // Cookie settings  
            //    options.Cookie.HttpOnly = true;
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
            //    options.LoginPath = "/Account/Login"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login  
            //    options.LogoutPath = "/Account/Logout"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout  
            //    options.AccessDeniedPath = "/Account/AccessDenied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied  
            //    options.SlidingExpiration = true;
            //});



            //Repository
            services.AddSingleton<IMvcControllerDiscovery, MvcControllerDiscovery>();
            services.AddTransient<IUserRep, UserRep>();
            services.AddTransient<IAccountRep, AccountRep>();
            services.AddTransient<ICRoleRep, RoleRep>();
            services.AddTransient<ISection, SectionRep>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
               // app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            //app.UseMyMiddleware();
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Page is not found");

            });
        }

        


    }
}
