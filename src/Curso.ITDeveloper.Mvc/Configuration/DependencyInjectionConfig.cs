using Curso.ITDeveloper.CrossCutting.Auxiliar;
using Curso.ITDeveloper.CrossCutting.Helpers;
using Curso.ITDeveloper.Domain.Interfaces;
using Curso.ITDeveloper.Mvc.Extensions.Filter;
using Curso.ITDeveloper.Mvc.Extensions.Identity;
using Curso.ITDeveloper.Mvc.Extensions.Identity.Services;
using Curso.ITDeveloper.Mvc.Infra;
using KissLog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Curso.ITDeveloper.Mvc.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUnitOfUpload, UnitOfUpload>();

            // =====/ Mantem o estado do contexto Http por toda a aplicação === //
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // ================================================================ //
            services.AddScoped<IUserInContext, AspNetUser>();
            services.AddScoped<IUserInAllLayer, UserInAllLayer>();
            // ================================================================ //

            // =====/ Adicionar Claims para HttpContext >> toda a Applications ================ //
            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, UserClaimsService>();
            // ================================================================================ //

            services.AddScoped((context) => Logger.Factory.Get());
            services.AddScoped<AuditorialIloggerFilter>();

            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(configuration);

            return services;
        }
    }
}
