using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cadastro.Models;
using Cadastro.Models.Enuns;
using Cadastro.Utils;

namespace Cadastro.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {
            
        }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Usuario user = new Usuario();      
            Criptografia.CriarSenhaHash("123456789", out byte[] hash, out byte[]salt);      
            user.Id = 1;
            user.Nome = "anilmar";
            user.Senha = string.Empty; 
            user.Senha_hash = hash;
            user.Senha_salt = salt;          
            user.Cpf = 12345678910;
            user.Email = "anilmar@gmail.com";
            user.Foto = null;
            user.Preferencia = PreferenciaEnum.Nao;
            user.TipoUsuario = TipoUsuarioEnum.Gerente;

            modelBuilder.Entity<Usuario>().HasData(user);

            Usuario user1 = new Usuario();      
            Criptografia.CriarSenhaHash("987654321", out byte[] passwordhash, out byte[]passwordsalt);      
            user1.Id = 2;
            user1.Nome = "natanael";
            user1.Senha = string.Empty; 
            user1.Senha_hash = passwordhash;
            user1.Senha_salt = passwordsalt;          
            user1.Cpf = 12345678911;
            user1.Email = "natanael@outlook.com";  
            user1.Foto = null;
            user1.Preferencia = 0;
            user1.TipoUsuario = TipoUsuarioEnum.Cliente;

            modelBuilder.Entity<Usuario>().HasData(user1);
        }
    }
}