using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TccApi.Models;
using TccApi.Models.Enuns;
using TccApi.Utils;

namespace TccApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Estabelecimento> Estabelecimentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            Usuario user = new Usuario();
            Criptografia.CriarSenhaHash("123456789", out byte[] hash, out byte[] salt);
            user.Id = 1;
            user.Cpf = 50023022232;
            user.Nome = "Agatha";
            user.Email = "Agatha.linhares@gmail.com";
            user.Foto = null;
            user.Senha_hash = hash;
            user.Senha_salt = salt;
            user.Senha = string.Empty;
            user.TipoUsuario = TipoClasseUsuario.Cliente;

            modelBuilder.Entity<Usuario>().HasData(user);

            modelBuilder.Entity<Estabelecimento>().HasData(
                new Estabelecimento() { Id = 1, Cnpj = "12123456/0001-12", Nome_est = "CutsCuts", Endereco = "Av. Ramiz Galvão", CEP = 02223001, Complemento = 04, Numero_est = 1082, TipoUsuario = TipoClasseUsuario.Estabelecimento, UsuarioId = 1 }
            );

            modelBuilder.Entity<Agendamento>().HasData(
                new Agendamento() { Id = 1, Hora_ag = DateTime.Now, Local_ag = "Av. Ramiz Galvão", data_ag = DateTime.Today, EstabelecimentoId = 1, UsuarioId = 1, FormasDePagamento = FormasDePagamento.PIX }
            );

            modelBuilder.Entity<Agendamento>()
    .HasOne(a => a.Usuario)
    .WithMany(u => u.Agendamentos)
    .HasForeignKey(a => a.UsuarioId)
    .OnDelete(DeleteBehavior.NoAction); // Desativar a operação de cascata

            // Configuração do relacionamento entre Usuario e Estabelecimento
            modelBuilder.Entity<Estabelecimento>()
                .HasOne(e => e.Usuario)
                .WithMany(u => u.Estabelecimentos)
                .HasForeignKey(e => e.UsuarioId)
                .OnDelete(DeleteBehavior.NoAction); // Desativar a operação de cascata

            // Configuração do relacionamento entre Agendamento e Estabelecimento
            modelBuilder.Entity<Agendamento>()
                .HasOne(a => a.Estabelecimentos)
                .WithMany(e => e.Agendamentos)
                .HasForeignKey(a => a.EstabelecimentoId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}