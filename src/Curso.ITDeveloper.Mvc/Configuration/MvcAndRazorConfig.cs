using Curso.ITDeveloper.Mvc.Extensions.Filter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Curso.ITDeveloper.Mvc.Configuration
{
    public static class MvcAndRazorConfig
    {
        public static IServiceCollection AddMvcAndRazor(this IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(AuditorialIloggerFilter));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();

            return services;
        }
    }
}
