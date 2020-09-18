using Curso.ITDeveloper.Mvc.Extensions.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Curso.ITDeveloper.Mvc.Extensions.ExtensionsMethods
{
    public static class ModelBuilderExtension
    {
        const string NOMECOMPLETO = "Andrews Cristhian";
        const string APELIDO = "Andrews";
        const string EMAIL = "andrewsfogo@gmail.com";
        const string PASSWORD = "Admin@123";
        const string ROLENAME = "Admin";
        const string USERNAME = EMAIL;
        const string ROLEID = "B8741F07-94B4-484A-B561-D3EFE1451915";
        const string USERID = "BA59D53A-32CE-435B-A964-23D0414D115B";

        public static ModelBuilder AddUserAndRole(this ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
              new IdentityRole
              {
                  Id = ROLEID,
                  Name = ROLENAME,
                  NormalizedName = ROLENAME.ToUpper()
              }
          );

            var phash = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(
               new ApplicationUser
               {
                   Id = USERID,
                   Apelido = APELIDO,
                   NomeCompleto = NOMECOMPLETO,
                   DataNascimento = DateTime.Now,
                   Email = EMAIL,
                   NormalizedEmail = EMAIL.ToUpper(),
                   UserName = USERNAME,
                   NormalizedUserName = USERNAME.ToUpper(),
                   PasswordHash = phash.HashPassword(null, PASSWORD),
                   EmailConfirmed = true
               });

            // Atribuir a role ao user
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = ROLEID,
                    UserId = USERID
                });

            return builder;
        }
    }
}
