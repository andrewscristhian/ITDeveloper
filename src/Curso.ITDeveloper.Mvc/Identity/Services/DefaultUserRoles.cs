using System;
using System.Threading.Tasks;
using Curso.ITDeveloper.Mvc.Data;
using Curso.ITDeveloper.Mvc.Extensions.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Curso.ITDeveloper.Mvc.Identity.Services
{
    public static class DefaultUserRoles
    {
        public static async Task Seed(ApplicationDbContext context, UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            const string nomeCompleto = "Andrews Cristhian";
            const string apelido = "Andrews";
            var dataNascimento = DateTime.Now;
            const string email = "andrewsfogo@gmail.com";
            const string password = "Admin@123";
            const string roleName = "Admin";
            const string userName = email;


            context.Database.Migrate();

            if (await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            if (await userManager.FindByNameAsync(userName) == null)
            {
                var user = new ApplicationUser
                {
                    Apelido = apelido,
                    NomeCompleto = nomeCompleto,
                    DataNascimento = dataNascimento,
                    UserName = userName,
                    Email = email,
                    PhoneNumber = "1199999999",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }
    }
}
