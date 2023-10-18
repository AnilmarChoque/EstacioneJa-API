using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cadastro.Models;
using Cadastro.Models.Enuns;
using Cadastro.Utils;
using EstacioneJa.Models;
using Estacione_já.Models;

namespace Cadastro.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {
            
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Estacionamento> Estacionamentos { get; set; }
        public DbSet<Sensor> Sensores { get; set; }
        public DbSet<Vaga> Vagas { get; set; }
        public DbSet<UsuarioVaga> UsuarioVagas { get; set; }

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

            Estacionamento estacionamento = new Estacionamento();           
            estacionamento.Id = 1;
            estacionamento.Nome = "Auto Park";
            estacionamento.UsuarioId = 1;
            modelBuilder.Entity<Usuario>().HasData(estacionamento);
        }
    }
}