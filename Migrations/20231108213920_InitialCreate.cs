using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TccApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cpf = table.Column<long>(type: "bigint", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    TipoUsuario = table.Column<int>(type: "int", nullable: false),
                    Senha_hash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Senha_salt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estabelecimentos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome_est = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CEP = table.Column<int>(type: "int", nullable: false),
                    Complemento = table.Column<int>(type: "int", nullable: false),
                    Numero_est = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    TipoUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estabelecimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estabelecimentos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Agendamentos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hora_ag = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Local_ag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    data_ag = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    EstabelecimentoId = table.Column<long>(type: "bigint", nullable: false),
                    FormasDePagamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Estabelecimentos_EstabelecimentoId",
                        column: x => x.EstabelecimentoId,
                        principalTable: "Estabelecimentos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Agendamentos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Cpf", "Email", "Foto", "Nome", "Senha_hash", "Senha_salt", "TipoUsuario" },
                values: new object[] { 1L, 50023022232L, "Agatha.linhares@gmail.com", null, "Agatha", new byte[] { 10, 226, 60, 110, 184, 81, 138, 12, 138, 157, 211, 146, 8, 116, 138, 164, 16, 140, 2, 198, 201, 176, 133, 64, 182, 44, 208, 199, 178, 9, 37, 194, 54, 255, 72, 86, 36, 140, 6, 40, 109, 76, 236, 253, 61, 243, 27, 21, 202, 201, 195, 187, 188, 1, 235, 251, 243, 35, 197, 61, 0, 168, 116, 121 }, new byte[] { 165, 229, 165, 147, 86, 48, 180, 211, 157, 86, 120, 167, 54, 253, 109, 66, 164, 37, 190, 44, 238, 106, 24, 96, 231, 243, 198, 127, 113, 129, 104, 52, 64, 251, 217, 238, 90, 134, 238, 247, 194, 108, 40, 187, 182, 223, 203, 22, 247, 214, 13, 31, 194, 84, 220, 28, 173, 44, 73, 124, 190, 148, 174, 51, 167, 30, 72, 68, 150, 140, 14, 66, 114, 91, 85, 82, 156, 103, 25, 107, 109, 218, 178, 16, 197, 134, 52, 125, 93, 84, 251, 19, 86, 10, 244, 192, 230, 196, 167, 101, 155, 80, 236, 240, 205, 107, 252, 44, 232, 219, 105, 251, 36, 183, 191, 171, 23, 131, 139, 246, 54, 7, 255, 22, 133, 65, 245, 152 }, 0 });

            migrationBuilder.InsertData(
                table: "Estabelecimentos",
                columns: new[] { "Id", "CEP", "Cnpj", "Complemento", "Endereco", "Nome_est", "Numero_est", "TipoUsuario", "UsuarioId" },
                values: new object[] { 1L, 2223001, "12123456/0001-12", 4, "Av. Ramiz Galvão", "CutsCuts", 1082, 1, 1L });

            migrationBuilder.InsertData(
                table: "Agendamentos",
                columns: new[] { "Id", "EstabelecimentoId", "FormasDePagamento", "Hora_ag", "Local_ag", "UsuarioId", "data_ag" },
                values: new object[] { 1L, 1L, 0, new DateTime(2023, 11, 8, 18, 39, 20, 299, DateTimeKind.Local).AddTicks(880), "Av. Ramiz Galvão", 1L, new DateTime(2023, 11, 8, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_EstabelecimentoId",
                table: "Agendamentos",
                column: "EstabelecimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_UsuarioId",
                table: "Agendamentos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimentos_UsuarioId",
                table: "Estabelecimentos",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamentos");

            migrationBuilder.DropTable(
                name: "Estabelecimentos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
