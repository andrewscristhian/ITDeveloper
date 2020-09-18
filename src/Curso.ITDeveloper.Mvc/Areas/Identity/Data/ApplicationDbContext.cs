using Curso.ITDeveloper.Mvc.Extensions.ExtensionsMethods;
using Curso.ITDeveloper.Mvc.Extensions.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Curso.ITDeveloper.Mvc.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            ModelBuilderExtension.AddUserAndRole(builder);

            base.OnModelCreating(builder);
        }
    }
}
