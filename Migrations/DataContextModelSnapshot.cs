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
                            Hora_ag = new DateTime(2023, 12, 5, 23, 48, 11, 810, DateTimeKind.Local).AddTicks(3767),
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

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

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
                            Cpf = "500.230.222-32",
                            Email = "Agatha.linhares@gmail.com",
                            Nome = "Agatha",
                            Senha_hash = new byte[] { 5, 94, 115, 78, 188, 245, 73, 29, 23, 179, 226, 25, 163, 49, 221, 232, 219, 47, 112, 1, 122, 29, 196, 227, 62, 134, 62, 41, 172, 222, 104, 146, 121, 116, 177, 123, 153, 188, 200, 223, 168, 183, 55, 207, 25, 140, 81, 17, 207, 183, 176, 127, 186, 5, 110, 101, 203, 224, 235, 221, 140, 35, 191, 93 },
                            Senha_salt = new byte[] { 232, 200, 122, 24, 10, 96, 21, 101, 12, 79, 48, 171, 195, 90, 65, 114, 164, 59, 49, 219, 12, 76, 103, 165, 233, 80, 178, 171, 36, 192, 134, 70, 200, 38, 115, 222, 40, 211, 24, 172, 40, 19, 71, 200, 144, 187, 208, 197, 200, 118, 173, 213, 147, 94, 178, 152, 109, 24, 168, 53, 228, 6, 59, 18, 252, 210, 230, 247, 148, 238, 70, 130, 117, 19, 81, 84, 225, 71, 168, 189, 189, 16, 59, 11, 130, 73, 244, 58, 215, 233, 89, 217, 66, 229, 142, 49, 13, 253, 93, 145, 201, 102, 114, 144, 103, 30, 33, 96, 0, 111, 200, 37, 161, 146, 81, 244, 48, 138, 200, 74, 31, 61, 121, 42, 34, 168, 56, 218 },
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
