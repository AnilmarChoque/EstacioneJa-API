﻿// <auto-generated />
using Cadastro.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cadastro.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231022044121_InicialCreate")]
    partial class InicialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cadastro.Models.Estacionamento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Estacionamentos");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Nome = "Auto Park",
                            UsuarioId = 1L
                        });
                });

            modelBuilder.Entity("Cadastro.Models.Sensor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Latitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("VagaId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("VagaId")
                        .IsUnique();

                    b.ToTable("Sensores");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Latitude = "68.4908",
                            Longitude = "-61.2506",
                            VagaId = 1L
                        });
                });

            modelBuilder.Entity("Cadastro.Models.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Latitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Preferencia")
                        .HasColumnType("int");

                    b.Property<byte[]>("Senha_hash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("Senha_salt")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Cpf = "12345678910",
                            Email = "anilmar@gmail.com",
                            Nome = "anilmar",
                            Preferencia = 1,
                            Senha_hash = new byte[] { 225, 55, 160, 126, 242, 104, 10, 55, 151, 16, 135, 57, 55, 11, 180, 194, 249, 229, 202, 168, 137, 214, 220, 252, 51, 109, 39, 35, 82, 158, 201, 160, 18, 49, 204, 252, 236, 71, 24, 244, 203, 40, 223, 27, 211, 184, 168, 161, 161, 45, 183, 6, 106, 113, 197, 196, 15, 49, 79, 213, 107, 129, 208, 151 },
                            Senha_salt = new byte[] { 232, 158, 12, 73, 176, 192, 199, 208, 180, 211, 173, 30, 64, 222, 152, 157, 50, 229, 242, 190, 198, 232, 113, 223, 104, 183, 39, 194, 91, 249, 54, 225, 118, 158, 19, 8, 151, 30, 133, 167, 158, 39, 35, 39, 79, 110, 0, 102, 138, 33, 238, 9, 62, 251, 42, 10, 157, 74, 41, 100, 243, 47, 180, 254, 140, 156, 234, 37, 25, 129, 4, 207, 71, 89, 251, 253, 67, 125, 161, 163, 16, 220, 16, 100, 191, 140, 165, 3, 236, 214, 48, 170, 47, 169, 117, 249, 109, 73, 187, 85, 246, 52, 161, 4, 211, 247, 138, 88, 81, 244, 175, 244, 44, 163, 241, 211, 164, 216, 189, 13, 201, 7, 186, 40, 90, 54, 39, 13 },
                            TipoUsuario = 2
                        });
                });

            modelBuilder.Entity("Cadastro.Models.Vaga", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Andar")
                        .HasColumnType("int");

                    b.Property<int>("Disponibilidade")
                        .HasColumnType("int");

                    b.Property<long>("EstacionamentoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Latitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Numero")
                        .HasColumnType("float");

                    b.Property<int>("Preferencia")
                        .HasColumnType("int");

                    b.Property<string>("Secao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EstacionamentoId");

                    b.ToTable("Vagas");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Andar = 1,
                            Disponibilidade = 1,
                            EstacionamentoId = 1L,
                            Latitude = "68.4908",
                            Longitude = "-61.2506",
                            Numero = 1.0,
                            Preferencia = 1,
                            Secao = "A1"
                        });
                });

            modelBuilder.Entity("Cadastro.Models.Estacionamento", b =>
                {
                    b.HasOne("Cadastro.Models.Usuario", "Usuario")
                        .WithMany("Estacionamentos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Cadastro.Models.Sensor", b =>
                {
                    b.HasOne("Cadastro.Models.Vaga", "Vaga")
                        .WithOne("Sensor")
                        .HasForeignKey("Cadastro.Models.Sensor", "VagaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vaga");
                });

            modelBuilder.Entity("Cadastro.Models.Vaga", b =>
                {
                    b.HasOne("Cadastro.Models.Estacionamento", "Estacionamento")
                        .WithMany("Vagas")
                        .HasForeignKey("EstacionamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estacionamento");
                });

            modelBuilder.Entity("Cadastro.Models.Estacionamento", b =>
                {
                    b.Navigation("Vagas");
                });

            modelBuilder.Entity("Cadastro.Models.Usuario", b =>
                {
                    b.Navigation("Estacionamentos");
                });

            modelBuilder.Entity("Cadastro.Models.Vaga", b =>
                {
                    b.Navigation("Sensor");
                });
#pragma warning restore 612, 618
        }
    }
}