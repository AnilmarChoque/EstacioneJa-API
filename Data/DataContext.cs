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
            user.Cpf = "12345678910";
            user.Email = "anilmar@gmail.com";
            user.Foto = null;
            user.Preferencia = PreferenciaEnum.Nao;
            user.TipoUsuario = TipoUsuarioEnum.Gerente;

            modelBuilder.Entity<Usuario>().HasData(user);

            modelBuilder.Entity<Estacionamento>().HasData(
            new Estacionamento { Id = 1, Nome = "Auto Park", UsuarioId = 1}
            );

            modelBuilder.Entity<Vaga>()
                .HasKey(v => v.Id);

            modelBuilder.Entity<Sensor>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Sensor>()
                .HasOne(s => s.Vaga)
                .WithOne(v => v.Sensor)
                .HasForeignKey<Sensor>(v => v.VagaId);
                

            modelBuilder.Entity<Vaga>().HasData
            (
                new Vaga { Id= 1, Latitude = "68.4908", Longitude = "-61.2506", Secao = "A1", Disponibilidade = DisponibilidadeEnum.livre, Andar = 1, Numero = 1, Preferencia = PreferenciaEnum.Nao, EstacionamentoId = 1}
            );

            modelBuilder.Entity<Sensor>().HasData
            (
                new Sensor { Id = 1, Latitude = "68.4908", Longitude = "-61.2506", VagaId =1}
            );

            modelBuilder.Entity<UsuarioVaga>()
                .HasKey(uv => new {uv.CodData});

            modelBuilder.Entity<UsuarioVaga>().HasData
            (                  
                new UsuarioVaga() {CodData = 1, Forma_pagamento = PagamentoEnum.Pix, Data = DateTime.Now, Receptor_pagamento = "Auto Park", Emissor_pagamento = "Anilmar", Ocupacao_inicial = DateTime.Now, Ocupacao_final = DateTime.Now, VagaId = 1, UsuarioId = 1}                       
            );

            modelBuilder.Entity<UsuarioVaga>()
                .HasOne(uv => uv.Vaga)
                .WithMany(v => v.UsuarioVagas)
                .HasForeignKey(uv => uv.VagaId)
                .OnDelete(DeleteBehavior.Restrict);



        }
    }
}