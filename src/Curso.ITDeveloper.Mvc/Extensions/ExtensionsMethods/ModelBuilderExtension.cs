using Curso.ITDeveloper.Domain.Models;
using Curso.ITDeveloper.Mvc.Extensions.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Reflection;

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

        public static ModelBuilder AddGenericos(this ModelBuilder builder)
        {

            var k = 0;
            string line;

            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            var csvPath = Path.Combine(outPutDirectory, "Csv\\Generico.CSV");
            string filePath = new Uri(csvPath).LocalPath;

            using (var fs = File.OpenRead(filePath))// Abrir arquivo para leitura
            using (var reader = new StreamReader(fs)) // Leitura do arquivo

                while ((line = reader.ReadLine()) != null) // Leitura linhas do arquivo
                {
                    var parts = line.Split(';'); // A partir do ponto e virgula, separar os dados em partes
                    var codigo = parts[0];
                    var generico = parts[1];
                    if (k > 0) // Caso o arquivo CSV contenha cabeçalho na primeira linha
                    {
                        builder.Entity<Generico>().HasData(
                            new Generico
                            {
                                //Id = Guid.NewGuid(),
                                Codigo = Convert.ToInt32(codigo),
                                Nome = generico
                            });
                    }
                    k++;
                }

            return builder;
        }

        public static ModelBuilder AddCid(this ModelBuilder builder)
        {

            var k = 0;
            string line;

            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            var csvPath = Path.Combine(outPutDirectory, "Csv\\Cid.CSV");
            string filePath = new Uri(csvPath).LocalPath;


            using (var fs = File.OpenRead(filePath))
            using (var reader = new StreamReader(fs))
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(';');

                    var cidinternalid = parts[0];
                    var codigo = parts[1];
                    var diagnostico = parts[2];

                    // Pular cabeçalho
                    if (k > 0)
                    {
                        //CidInternalId;Codigo;Diagnostico
                        builder.Entity<Cid>().HasData(new Cid
                        {
                            CidInternalId = Convert.ToInt32(cidinternalid),
                            Codigo = codigo,
                            Diagnostico = diagnostico
                        });
                    }

                    k++;
                }

            return builder;
        }
    }
}
