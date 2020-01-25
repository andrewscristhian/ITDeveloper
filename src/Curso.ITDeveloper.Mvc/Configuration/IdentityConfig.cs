using System;
using Curso.ITDeveloper.Mvc.Data;
using Curso.ITDeveloper.Mvc.Extensions.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Curso.ITDeveloper.Mvc.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Todo: Controlar nosso fluxo de identidade entre outras coisas com cookies
            services.ConfigureApplicationCookie(c =>
            {
                c.AccessDeniedPath = "/Identity/Account/AccessDenied";
                c.Cookie.Name = "CursoAspNetCoreUdemy";
                c.Cookie.HttpOnly = true;
                c.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                c.SlidingExpiration = true;
                c.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                c.LoginPath = "/Identity/Account/Login";
                c.LogoutPath = "/Identity/Account/Logout";
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultITDeveloper")));

            services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    // User config
                    options.User.RequireUniqueEmail = true;
                    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqsrtuvwxyzABCDEFGHIJKLMNOPQRSTUVWXWZ0123456789-._@+";

                    // Lockout config
                    options.Lockout.AllowedForNewUsers = true;
                    options.Lockout.MaxFailedAccessAttempts = 4;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(4);

                    // Signin config
                    options.SignIn.RequireConfirmedPhoneNumber = false;
                    options.SignIn.RequireConfirmedAccount = false;
                    options.SignIn.RequireConfirmedEmail = false;

                    //Password config
                    options.Password.RequireUppercase = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireDigit = true;
                    options.Password.RequiredLength = 8;
                    options.Password.RequiredUniqueChars = 2; // Qtde repeticoes mesma letra
                }).AddRoles<IdentityRole>()
                //.AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }
    }
}
