using System;
using System.Text;
using CleanArchitecture.Domain.Identity.AppSettings;
using CleanArchitecture.Domain.Identity.Models;
using CleanArchitecture.Domain.Models.Entities;
using CleanArchitecture.Infrastructure.Data.Context;
using CleanArchitecture.Infrastructure.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
namespace API
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
            }).AddEntityFrameworkStores<UniDbContext>().AddDefaultTokenProviders();

            services.AddControllersWithViews();

            services.AddDbContext<UniDbContext>(options =>
                options.UseNpgsql(
                    Configuration.GetConnectionString("DefaultConnection")));


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TheCodeBuzz-Service", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }

                    }
                });
            });


            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    // ValidIssuer = Configuration["JwtToken:Issuer"],
                    //ValidAudience = Configuration["JwtToken:Issuer"],

                    IssuerSigningKey =
                        new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Configuration["JwtToken:SecretKey"])) //Configuration["JwtToken:SecretKey"]
                };
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);




            services.AddControllers();

            // services.AddMediatR(typeof(Startup));
            RegisterServices(services);



            #region Api Versioning

            // Add API Versioning to the Project
            services.AddApiVersioning(config =>
            {
                // Specify the default API Version as 1.0
                config.DefaultApiVersion = new ApiVersion(1, 0);
                // If the client hasn't specified the API version in the request, use the default API version number
                config.AssumeDefaultVersionWhenUnspecified = true;
                // Advertise the API versions supported for the particular endpoint
                config.ReportApiVersions = true;
            });

            #endregion


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseSwagger(c =>
            {

            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestService");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // Shows UseCors with CorsPolicyBuilder.
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)); // allow any origin

            // .AllowCredentials()); // allow credentials
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

        private static void RegisterServices(IServiceCollection services) =>
            services.RegisterServices();
    }
}