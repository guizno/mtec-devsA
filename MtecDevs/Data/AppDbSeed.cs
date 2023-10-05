using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MtecDevs.Models;
namespace MtecDevs.Data;

public class NewBaseType
{
}

public class AppDbSeed
{
    public AppDbSeed(ModelBuilder builder)
    {
        #region Popular dos dados de TipoDev
        List<TipoDev> tipoDevs = new() {
            new TipoDev() {
                Id = 1,
                Nome = "FullStack"
            }, 
            new TipoDev() {
                Id = 2,
                Nome = "FrontEnd"
            },
            new TipoDev() {
                Id = 3,
                Nome = "BackEnd"
            },
            new TipoDev() {
                Id = 4,
                Nome = "Design"
            },
            new TipoDev() {
                Id = 5,
                Nome = "Jogos"
            }
        };
        builder.Entity<TipoDev>().HasData(tipoDevs);
        #endregion
        #region Popular dos dados Perfis de Usuário
        List<IdentityRole> perfis = new() {
            new IdentityRole() {
                Id = Guid.NewGuid().ToString(),
                Name = "Administrador",
                NormalizedName = "ADMINISTRADOR"
            },
            new IdentityRole() {
                Id = Guid.NewGuid().ToString(),
                Name = "Moderador",
                NormalizedName = "MODERADOR"
            },
            new IdentityRole() {
                Id = Guid.NewGuid().ToString(),
                Name = "Usuário",
                NormalizedName = "USUÁRIO"
            }
        };
        builder.Entity<IdentityRole>().HasData(perfis);
        #endregion
        #region Popular Dados de Usuário
        // Lista de IdentityUser
        List<IdentityUser> users = new() {
            new IdentityUser() {
                Id = Guid.NewGuid().ToString(),
                UserName = "ArthurBuzacarini",
                NormalizedUserName = "ARTHURBUZACARINI",
                Email = "guizinho.zaza14@gmail.com", 
                NormalizedEmail = "GUIZINHO.ZAZA14@GMAIL.COM",
                EmailConfirmed = true,
                LockoutEnabled = true
            }
        };
        //Criptografar a senha do IdentityUser
        foreach (var user in users)
        {
            PasswordHasher<IdentityUser> password = new();
            user.PasswordHash = password.HashPassword(user, "@Etec123");
        } 
        builder.Entity<IdentityUser>().HasData(users);

        //Criar o usuário
        List<Usuario> usuarios = new(){
            new Usuario() {
                UserId = users[0].Id,
                Nome = "Arthur Buzacarini",
                DataNascimento = DateTime.Parse("21/09/2006"),
                Foto = "/img/usuarios/arthur.png",
                TipoDevId = 2
            }
        };
        builder.Entity<Usuario>().HasData(usuarios);

        //Definir o perfil de cada usuário criado
        List<IdentityUserRole<string>> userRoles = new() {
            new IdentityUserRole<string>() {
                UserId = users[0].Id,
                RoleId = perfis[0].Id
            }
        };
        builder.Entity<IdentityRole<string>>().HasData(userRoles);
        #endregion
    }
}