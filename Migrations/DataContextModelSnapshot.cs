﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TccApi.Data;

#nullable disable

namespace TccApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TccApi.Models.Agendamento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("EstabelecimentoId")
                        .HasColumnType("bigint");

                    b.Property<int>("FormasDePagamento")
                        .HasColumnType("int");

                    b.Property<DateTime>("Hora_ag")
                        .HasColumnType("datetime2");

                    b.Property<string>("Local_ag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("data_ag")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EstabelecimentoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Agendamentos");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            EstabelecimentoId = 1L,
                            FormasDePagamento = 0,
                            Hora_ag = new DateTime(2023, 12, 5, 23, 25, 42, 96, DateTimeKind.Local).AddTicks(3410),
                            Local_ag = "Av. Ramiz Galvão",
                            UsuarioId = 1L,
                            data_ag = new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Local)
                        });
                });

            modelBuilder.Entity("TccApi.Models.Estabelecimento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("CEP")
                        .HasColumnType("int");

                    b.Property<string>("Cnpj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Complemento")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome_est")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero_est")
                        .HasColumnType("int");

                    b.Property<byte[]>("Senha_hash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("Senha_salt")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("int");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Estabelecimentos");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CEP = 2223001,
                            Cnpj = "12123456/0001-12",
                            Complemento = 4,
                            Endereco = "Av. Ramiz Galvão",
                            Nome_est = "CutsCuts",
                            Numero_est = 1082,
                            TipoUsuario = 1,
                            UsuarioId = 1L
                        });
                });

            modelBuilder.Entity("TccApi.Models.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("Cpf")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

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
                            Cpf = 50023022232L,
                            Email = "Agatha.linhares@gmail.com",
                            Nome = "Agatha",
                            Senha_hash = new byte[] { 99, 19, 197, 131, 175, 169, 231, 57, 78, 116, 111, 119, 253, 36, 139, 75, 12, 110, 191, 58, 81, 183, 11, 127, 210, 194, 221, 226, 101, 171, 81, 173, 203, 112, 131, 94, 135, 56, 26, 25, 138, 95, 55, 136, 172, 239, 183, 213, 178, 37, 136, 111, 35, 33, 167, 63, 176, 43, 213, 115, 112, 126, 190, 224 },
                            Senha_salt = new byte[] { 153, 18, 32, 53, 32, 56, 214, 176, 190, 32, 226, 191, 25, 161, 188, 30, 22, 222, 111, 113, 116, 192, 60, 125, 29, 144, 60, 105, 38, 250, 252, 168, 95, 24, 82, 125, 13, 70, 122, 209, 221, 102, 107, 251, 149, 205, 32, 166, 139, 58, 40, 123, 220, 161, 201, 93, 129, 172, 212, 200, 17, 105, 22, 108, 203, 184, 14, 128, 26, 52, 0, 28, 167, 53, 77, 240, 119, 72, 177, 172, 185, 81, 151, 81, 81, 63, 238, 140, 104, 14, 128, 174, 229, 135, 218, 200, 130, 225, 153, 153, 66, 217, 124, 204, 154, 68, 107, 77, 153, 249, 90, 10, 137, 142, 5, 173, 129, 225, 231, 239, 52, 210, 13, 125, 150, 180, 28, 248 },
                            TipoUsuario = 0
                        });
                });

            modelBuilder.Entity("TccApi.Models.Agendamento", b =>
                {
                    b.HasOne("TccApi.Models.Estabelecimento", "Estabelecimentos")
                        .WithMany("Agendamentos")
                        .HasForeignKey("EstabelecimentoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TccApi.Models.Usuario", "Usuario")
                        .WithMany("Agendamentos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Estabelecimentos");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("TccApi.Models.Estabelecimento", b =>
                {
                    b.HasOne("TccApi.Models.Usuario", "Usuario")
                        .WithMany("Estabelecimentos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("TccApi.Models.Estabelecimento", b =>
                {
                    b.Navigation("Agendamentos");
                });

            modelBuilder.Entity("TccApi.Models.Usuario", b =>
                {
                    b.Navigation("Agendamentos");

                    b.Navigation("Estabelecimentos");
                });
#pragma warning restore 612, 618
        }
    }
}
