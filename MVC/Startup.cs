using System;
using CleanArchitecture.Domain.Identity.AppSettings;
using CleanArchitecture.Domain.Identity.Models;
using CleanArchitecture.Infrastructure.Data.Context;
using CleanArchitecture.Infrastructure.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Configuration from AppSettings
            services.Configure<JwtToken>(Configuration.GetSection("JwtToken"));

            services.AddDbContext<UniDbContext>(options =>
                options.UseNpgsql(
                    Configuration.GetConnectionString("DefaultConnection")));




            //User Manager Service
            services.AddIdentity<User, IdentityRole>(settings =>
            {
                settings.Lockout.MaxFailedAccessAttempts = 3;
                settings.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                settings.Password.RequiredLength = 4;
                settings.Password.RequireNonAlphanumeric = false;
                settings.Password.RequireUppercase = false;
                settings.Password.RequireDigit = false;
                settings.Password.RequireLowercase = false;
                settings.User.RequireUniqueEmail = true;
                settings.SignIn.RequireConfirmedAccount = true;
            }).AddEntityFrameworkStores<UniDbContext>().AddDefaultTokenProviders();





            //   services.AddDatabaseDeveloperPageExceptionFilter();
            //
            // services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
            //     .AddEntityFrameworkStores<UniDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddMvc();

            RegisterServices(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }

        private static void RegisterServices(IServiceCollection services) =>
            services.RegisterServices();
    }
}